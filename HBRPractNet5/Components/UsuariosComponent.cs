    using ProyectoPropietaria.Models;
using ProyectoPropietaria.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPropietaria.Components
{
    public class UsuariosComponent : ViewComponent
    {
        private ProyectoPropietariaContext _context;
        public UsuariosComponent(ProyectoPropietariaContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<UsuariosViewModel> usuarios = new List<UsuariosViewModel>();

            foreach (Usuario usuario in _context.Usuarios.ToList())
            {
                usuarios.Add(new UsuariosViewModel()
                { Usuario = usuario });
            }
            return View(usuarios);
        }
    }
}
