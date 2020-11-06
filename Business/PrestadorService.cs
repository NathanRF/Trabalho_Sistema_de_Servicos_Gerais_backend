using Microsoft.AspNetCore.Identity;
using SSG_API.Data;
using SSG_API.Domain;
using SSG_API.Security;
using System.Linq;

namespace SSG_API.Business
{
    public class PrestadorService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;


        public PrestadorService(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        public object GetByEmail(string email)
        {
            var user = _applicationDbContext.Users.AsQueryable()
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
            var user = _applicationDbContext.Users.AsQueryable()
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
    }
}
