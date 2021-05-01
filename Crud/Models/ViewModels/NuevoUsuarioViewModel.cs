using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Crud.Models.ViewModels
{
    public class NuevoUsuarioViewModel
    {

        public int IdUsuario { get; set; }

        [Required]
        [Display(Name = "txtUserName")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "txtNombre")]       
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "txtEmail")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "txtTelefono")]
        [StringLength(50)]
        public string Telefono { get; set; }
    }
}