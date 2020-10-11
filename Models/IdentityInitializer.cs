using System;
using Microsoft.AspNetCore.Identity;
using APIProdutos.Data;
using APIProdutos.Models;

namespace APIProdutos.Security
{
    public class IdentityInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityInitializer(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_context.Database.EnsureCreated())
            {
                if (!_roleManager.RoleExistsAsync(Roles.Admin).Result)
                {
                    var resultado = _roleManager.CreateAsync(
                        new IdentityRole(Roles.Admin)).Result;
                    if (!resultado.Succeeded)
                    {
                        throw new Exception(
                            $"Erro durante a criação da role {Roles.Admin}.");
                    }
                }
                if (!_roleManager.RoleExistsAsync(Roles.Cliente).Result)
                {
                    var resultado = _roleManager.CreateAsync(
                        new IdentityRole(Roles.Cliente)).Result;
                    if (!resultado.Succeeded)
                    {
                        throw new Exception(
                            $"Erro durante a criação da role {Roles.Cliente}.");
                    }
                }
                if (!_roleManager.RoleExistsAsync(Roles.Prestador).Result)
                {
                    var resultado = _roleManager.CreateAsync(
                        new IdentityRole(Roles.Prestador)).Result;
                    if (!resultado.Succeeded)
                    {
                        throw new Exception(
                            $"Erro durante a criação da role {Roles.Prestador}.");
                    }
                }

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "admin_apiprodutos",
                        Email = "admin-apiprodutos@teste.com.br",
                        EmailConfirmed = true
                    }, "AdminAPIProdutos01!", Roles.Admin);

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "usrinvalido_apiprodutos",
                        Email = "usrinvalido-apiprodutos@teste.com.br",
                        EmailConfirmed = true
                    }, "UsrInvAPIProdutos01!");

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "PrestadorExemplo",
                        Email = "prestadorexemplo@teste.com.br",
                        EmailConfirmed = true
                    }, "PrestadorExemplo01!", Roles.Prestador);

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "ClienteExemplo",
                        Email = "clienteexemplo@teste.com.br",
                        EmailConfirmed = true
                    }, "ClienteExemplo01!", Roles.Cliente);
            }
        }
        private void CreateUser(
            ApplicationUser user,
            string password,
            string initialRole = null)
        {
            if (_userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var resultado = _userManager
                    .CreateAsync(user, password).Result;

                if (resultado.Succeeded &&
                    !String.IsNullOrWhiteSpace(initialRole))
                {
                    _userManager.AddToRoleAsync(user, initialRole).Wait();
                }
            }
        }
    }
}