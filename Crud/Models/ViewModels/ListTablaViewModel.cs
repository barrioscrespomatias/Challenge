using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud.Models.ViewModels
{
    public class ListTablaViewModel
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Nombre{ get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

    }
}