using Azure;
using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Application.Models.ViewModel.Login;
using Finanzauto.PowerBI.Domain;
using Finanzauto.PowerBI.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Auth.Services
{
    public class LoginAuth
    {
        IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly PowerBIDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public LoginAuth(
           IConfiguration configuration,
           IUnitOfWork unitOfWork,
           IMediator mediator,
           PowerBIDbContext context)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _context = context;
        }
        private DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            var dateTimeVal = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeVal = dateTimeVal.AddSeconds(unixTimeStamp).ToUniversalTime();
            return dateTimeVal;
        }
        private string GenerateRandomTokenCharacters(int lenght)
        {
            try
            {
                var random = new Random();
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                return new string(Enumerable.Repeat(chars, lenght)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Error random characters del refresh token.", ex);
            }
        }

        public Tuple<string, RefreshToken> GenerateToken(string rolDescription, int usrId, string usrDomain, bool boolTime)
        {
            try
            {
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
                List<string> roles = new List<string>();
                roles.Add(rolDescription);

                var roleClaim = new List<Claim>();
                foreach (var role in roles)
                    roleClaim.Add(new Claim(ClaimTypes.Role, role));

                var claimsIdentity = new[]
                {
                new Claim("Id", usrId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, usrDomain),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }.Union(roleClaim);

                var tokenDescriptor = new SecurityTokenDescriptor();

                if (boolTime)
                {
                    tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claimsIdentity),
                        Expires = DateTime.UtcNow.AddHours(4),
                        SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
                    };
                }
                else
                {
                    tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claimsIdentity),
                        Expires = DateTime.UtcNow.AddMinutes(30),
                        SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
                    };
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                var refreshToken = new RefreshToken
                {
                    JwtId = token.Id,
                    usrId = usrId.ToString(),
                    IsUsed = false,
                    IsRevoked = false,
                    Token = $"{GenerateRandomTokenCharacters(36)}{Guid.NewGuid()}",
                    CreatedDate = DateTime.UtcNow,
                    ExpireDate = DateTime.UtcNow.AddHours(2)
                };
                return new Tuple<string, RefreshToken>(jwtToken, refreshToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Crear/Generar el token.", ex);
            }
        }

        public async Task<Authorize> RefreshToken(string token, string refresh)
        {
            try
            {
                var queryToken = await _context.Tokens.Where(x => x.tknToken.Equals(token) && x.tknRefreshToken.Equals(refresh)).ToListAsync();
                var queryUser = await _context.Users.Where(x => x.usrId == queryToken[0].usrId).ToListAsync();
                var queryRole = await _context.Roles.Where(x => x.rolId == queryUser[0].rolId).ToListAsync();
                var paramsToken = GenerateToken(queryRole[0].rolDescription, queryUser[0].usrId, queryUser[0].usrDomainName, true);
                try
                {
                    if (queryToken != null)
                    {
                        if (!queryToken[0].tknIsUsed)
                        {
                            queryToken[0].usrId = Int32.Parse(paramsToken.Item2.usrId);
                            queryToken[0].tknToken = paramsToken.Item1;
                            queryToken[0].tknRefreshToken = paramsToken.Item2.Token;
                            queryToken[0].tknIsUsed = true;
                            queryToken[0].JwtId = paramsToken.Item2.JwtId;
                            queryToken[0].ExpirateDate = DateTime.Now.AddHours(4);
                            queryToken[0].modifyDate = DateTime.Now;
                            queryToken[0].modifyUser = Int32.Parse(paramsToken.Item2.usrId);
                            _context.Tokens.Update(queryToken[0]);
                            await _context.SaveChangesAsync();
                        }
                    }
                    return new Authorize
                    {
                        usrId = Int32.Parse(paramsToken.Item2.usrId),
                        tknId = paramsToken.Item2.JwtId,
                        usrDomainName = queryUser[0].usrDomainName,
                        rolId = queryRole[0].rolId,
                        rolDescription = queryRole[0].rolDescription,
                        token = paramsToken.Item1,
                        refreshToken = paramsToken.Item2.Token,
                    };
                }
                catch (Exception ax)
                {
                    throw new Exception("Error al hacer put del refresh.", ax);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la obtencion de datos del refresh.", ex);
            }
        }
        public string ServiceLogin(string username, string password)
        {
            try
            {
                string api = _configuration["Apis:Finanzauto"];
                var client = new RestClient(api);
                RestRequest request = new RestRequest("", Method.Post);
                String body = @"{
                " + "\n" + @"  ""User"": ""@username"",
                " + "\n" + @"  ""Passwd"": ""@password"",
                " + "\n" + @"  ""IdAplicativo"": 3,
                " + "\n" + @"  ""Firma"": ""KdNESJeIadQ+U+Q5Qs+8BQ==""
                " + "\n" +
                @"}";
                body = body.Replace("@username", username);
                body = body.Replace("@password", password);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                RestResponse response = client.Execute(request);

                return response.Content;
            }
            catch (Exception ex)
            {
                throw new Exception("Error respuesta Login Finanzauto.", ex);
            }
        }
        public async Task<List<Authorize>> GetUsersRole(string userDomain)
        {
            try
            {
                var user = _context.Users.Where(x => x.usrDomainName == userDomain);
                var role = _context.Roles.Where(x => x.rolId == user.FirstOrDefault().rolId);
                List<Authorize> result = new List<Authorize>();
                result.Add(new Authorize()
                {
                    usrId = user.FirstOrDefault().usrId,
                    usrDomainName = user.FirstOrDefault().usrDomainName,
                    rolId = role.FirstOrDefault().rolId,
                    rolDescription = role.FirstOrDefault().rolDescription
                });
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error obtencion de roles del usuario.", ex);
            }
        }
        public async Task<Tuple<Authorize, Tokens>> Login(string usr, string pass)
        {
            try
            {
                var login = ServiceLogin(usr, pass);
                var authorize = GetUsersRole(usr);
                if (usr != null)
                {
                    if (login != null)
                    {
                        var paramsToken = GenerateToken(authorize.Result[0].rolDescription, authorize.Result[0].usrId, usr, false);
                        var loginResponse = JsonConvert.DeserializeObject<RespMensaje>(login);

                        authorize.Result[0].refreshToken = paramsToken.Item2.Token;
                        authorize.Result[0].token = paramsToken.Item1;
                        authorize.Result[0].tknId = paramsToken.Item2.JwtId;

                        var saveToken = new Tokens
                        {
                            usrId = authorize.Result[0].usrId,
                            tknToken = authorize.Result[0].token,
                            tknRefreshToken = authorize.Result[0].refreshToken,
                            tknIsUsed = false,
                            JwtId = authorize.Result[0].tknId,
                            ExpirateDate = DateTime.Now.AddMinutes(30),
                            state = true,
                            createDate = DateTime.Now,
                            createUser = authorize.Result[0].usrId,
                            CodigoMensaje = loginResponse.Mensaje.CodigoMensaje,// aqui se debe retornar el codigo de respuesta
                            DescMensaje = loginResponse.Mensaje.DescMensaje // aqui se debe retornar el codigo de respuesta

                        };

                        var tokenVM = new Authorize
                        {
                            usrId = authorize.Result[0].usrId,
                            tknId = authorize.Result[0].tknId,
                            usrDomainName = authorize.Result[0].usrDomainName,
                            rolId = authorize.Result[0].rolId,
                            rolDescription = authorize.Result[0].rolDescription,
                            token = authorize.Result[0].token,
                            refreshToken = authorize.Result[0].refreshToken,
                            CodigoMensaje = loginResponse.Mensaje.CodigoMensaje,// aqui se debe retornar el codigo de respuesta
                            DescMensaje = loginResponse.Mensaje.DescMensaje // aqui se debe retornar el codigo de respuesta

                        };

                        var update = await _context.Tokens.Where(x => x.usrId == saveToken.usrId).ToListAsync();

                        if (update.Count != 0)
                        {
                            update[0].usrId = saveToken.usrId;
                            update[0].tknToken = saveToken.tknToken;
                            update[0].tknRefreshToken = saveToken.tknRefreshToken;
                            update[0].tknIsUsed = false;
                            update[0].JwtId = saveToken.JwtId;
                            update[0].ExpirateDate = DateTime.Now.AddMinutes(30);
                            update[0].state = true;
                            update[0].modifyDate = DateTime.Now;
                            update[0].modifyUser = authorize.Result[0].usrId;
                            _context.Tokens.Update(update[0]);
                        }
                        else
                        {
                            _context.Tokens.AddAsync(saveToken);
                        }
                        await _context.SaveChangesAsync();
                        return new Tuple<Authorize, Tokens>(tokenVM, saveToken);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error de logeo.", ex);
            }
        }
    }
}
