using Microsoft.AspNetCore.Identity;
using SSG_API.Data;
using SSG_API.Domain;
using SSG_API.Security;
using System.Linq;

namespace SSG_API.Business
{
    public class PrestadorService
    {
        private readonly IdentityDbContext _identityDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public PrestadorService(IdentityDbContext identityDbContext, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _identityDbContext = identityDbContext;
        }

        public object GetByEmail(string email)
        {
            var user = _identityDbContext.Users.AsQueryable()
                .Where(p => p.NormalizedEmail == email.Trim().ToUpper())
                .Select(p => p)
                .FirstOrDefault();

            if (user != null && _userManager.IsInRoleAsync(user, Roles.Prestador).Result)
                return new
                {
                    user.Id,
                    user.Email,
                    user.NomeCompleto,
                    user.Telefone,
                    user.LinkFoto,
                    user.Endereco,
                    user.Avaliacao,
                    user.Cpf
                };

            return null;
        }

        public object GetById(string id)
        {
            var user = _identityDbContext.Users.AsQueryable()
                .Where(p => p.Id == id.Trim().ToUpper())
                .Select(p => p)
                .FirstOrDefault();

            if (user != null && _userManager.IsInRoleAsync(user, Roles.Prestador).Result)
                    return new
                    {
                        user.Id,
                        user.Email,
                        user.NomeCompleto,
                        user.Telefone,
                        user.LinkFoto,
                        user.Endereco,
                        user.Avaliacao,
                        user.Cpf
                    };

            return null;
        }

        public object GetByUserName(string userName)
        {
            var user = _identityDbContext.Users.AsQueryable()
                .Where(p => p.NormalizedUserName == userName.Trim().ToUpper())
                .Select(p => p)
                .FirstOrDefault();

            if (user != null && _userManager.IsInRoleAsync(user, Roles.Prestador).Result)
                return new
                {
                    user.Id,
                    user.Email,
                    user.NomeCompleto,
                    user.Telefone,
                    user.LinkFoto,
                    user.Endereco,
                    user.Avaliacao,
                    user.Cpf
                };

            return null;
        }
    }
}
