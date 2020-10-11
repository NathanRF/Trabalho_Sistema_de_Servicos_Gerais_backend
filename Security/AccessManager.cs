using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SSG_API.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace SSG_API.Security
{
    public class AccessManager
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;

        public AccessManager(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            SigningConfigurations signingConfigurations,
            TokenConfigurations tokenConfigurations)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
        }

        public bool ValidateLoginCredentials(UserModel user)
        {
            bool credenciaisValidas = false;
            if (user != null && !String.IsNullOrWhiteSpace(user.UserID))
            {
                // Verifica a existência do usuário nas tabelas do
                // ASP.NET Core Identity
                var userIdentity = _userManager
                    .FindByNameAsync(user.UserID).Result;
                if (userIdentity != null)
                {
                    // Efetua o login com base no Id do usuário e sua senha
                    var resultadoLogin = _signInManager
                        .CheckPasswordSignInAsync(userIdentity, user.Password, false)
                        .Result;
                    if (resultadoLogin.Succeeded)
                    {
                        // Verifica se o usuário em questão possui
                        // a role Acesso-APIProdutos
                        credenciaisValidas = _userManager.IsInRoleAsync(
                            userIdentity, Roles.Admin).Result
                            || _userManager.IsInRoleAsync(userIdentity, Roles.Cliente).Result
                            || _userManager.IsInRoleAsync(userIdentity, Roles.Prestador).Result;
                    }
                }
            }

            return credenciaisValidas;
        }

        public string ValidateSignUp(UserModel user)
        {
            if
            (
                user != null
                && !String.IsNullOrWhiteSpace(user.UserID)
                && !String.IsNullOrWhiteSpace(user.Biografia)
                && !String.IsNullOrWhiteSpace(user.Endereco)
                && !String.IsNullOrWhiteSpace(user.LinkFoto)
                && !String.IsNullOrWhiteSpace(user.NomeCompleto)
                && !String.IsNullOrWhiteSpace(user.Password)
                && !String.IsNullOrWhiteSpace(user.Telefone)
                && !String.IsNullOrWhiteSpace(user.Tipo)
            )
            {
                ApplicationUser applicationUser;

                if (user.Tipo == "Prestador")
                {
                    applicationUser = new ApplicationUserPrestador
                    {
                        Email = user.UserID,
                        EmailConfirmed = true,
                        UserName = user.UserID,
                        Biografia = user.Biografia,
                        Endereco = user.Endereco,
                        LinkFoto = user.LinkFoto,
                        NomeCompleto = user.NomeCompleto,
                        Telefone = user.Telefone
                    };
                    return _userManager.CreateAsync(applicationUser, user.Password)
                        .Result
                        .Succeeded
                        ? "Succeeded"
                        : "Failed";
                }
                else if (user.Tipo == "Cliente")
                {
                    applicationUser = new ApplicationUserContratante
                    {
                        Email = user.UserID,
                        EmailConfirmed = true,
                        UserName = user.UserID,
                        Endereco = user.Endereco,
                        LinkFoto = user.LinkFoto,
                        NomeCompleto = user.NomeCompleto,
                        Telefone = user.Telefone
                    };
                    return _userManager.CreateAsync(applicationUser, user.Password)
                        .Result
                        .Succeeded
                        ? "Succeeded"
                        : "Failed";
                }
            }

            return "Failed";
        }

        public Token GenerateToken(UserModel user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.UserID, "Login"),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserID)
                }
            );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao +
                TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            return new Token()
            {
                Authenticated = true,
                Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token,
                Message = "OK",
                Roles = _userManager.GetRolesAsync(_userManager.FindByNameAsync(user.UserID).Result).Result.ToArray<String>()
            };
        }
    }
}