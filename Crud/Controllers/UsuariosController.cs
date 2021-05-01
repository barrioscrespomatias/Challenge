using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud.Models;
using Crud.Models.ViewModels;

namespace Crud.Controllers
{
    public class UsuariosController : Controller
    {       

        /// <summary>
        /// Toma de la base de datos cada uno de los campos correspondientes.
        /// Los retorna en forma de lista.
        /// Los usuarios se envian al index para cargar la página principal
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<ListTablaViewModel> listaDeUsuarios;

            try
            {            
            using (MandatarioEntities db = new MandatarioEntities())
            {
                listaDeUsuarios = (from campo in db.Usuarios
                                   select new ListTablaViewModel
                                   {
                                       //Representacion de los atributos de clase 
                                       //tomados desde la DB.
                                       IdUsuario = campo.IdUsuario,
                                       UserName = campo.UserName,
                                       Nombre = campo.Nombre,
                                       Email = campo.Email,
                                       Telefono = campo.Telefono
                                   }).ToList();
            }
            }
            catch(Exception ex)
            {
                return View("ErrorDB");
            }
            return View(listaDeUsuarios);
        }

        public ActionResult ErrorDB()
        {
            return View();
        }

        /// <summary>
        /// Retorna la vista con los usuarios.
        /// </summary>
        /// <returns></returns>
        public ActionResult NuevoUsuario()
        {
            return View();
        }


        /// <summary>
        /// Toma los atributos del fomulario enviados por post. 
        /// Captura cada uno de los mismos mediante la propiedad Name del formulario
        /// y los ingresa en una nueva fila de la DB.
        /// Maneja excepciones por el uso de DB.
        /// </summary>
        /// <param name="txtNombre">Parámetro del formulario HTML nombre del usuario.</param>
        /// <param name="txtApellido">Parámetro del formulario HTML nombre del usuario.</param>
        /// <param name="txtUserName">Parámetro del formulario HTML nickName del usuario.</param>
        /// <param name="txtEmail">Parámetro del formulario HTML email del usuario.</param>
        /// <param name="txtTelefono">Parámetro del formulario HTML teléfono del usuario.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NuevoUsuario(string txtNombre,
                                        string txtApellido,
                                        string txtUserName,
                                        string txtEmail,
                                        string txtTelefono)
        {
            try
            {
                //Validaciones del modelo FrmNuevoUsuario
                if (ModelState.IsValid)
                {
                    using (MandatarioEntities db = new MandatarioEntities())
                    {
                        //Cargo el campo de la tabla Usuarios 
                        var nuevFila = new Usuarios();
                        nuevFila.UserName = txtUserName;
                        nuevFila.Nombre = txtNombre;
                        nuevFila.Email = txtEmail;
                        nuevFila.Telefono = txtTelefono;

                        //Agregar y guardar
                        db.Usuarios.Add(nuevFila);
                        db.SaveChanges();
                    }
                }
                return Redirect("~/Usuarios/");
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }




        /// <summary>
        /// Recibe los datos del formulario para enviarlos a la vista Editar.
        /// Los datos son recibidos desde el boton Editar del formulario por Métod GET tomados
        /// desde la URL. Busca en la DB si existe el usuario. Si existe lo carga en el modelo que 
        /// va a ser enviado hacia la vista.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Editar(int id)
        {
            NuevoUsuarioViewModel model = new NuevoUsuarioViewModel();

            using (var db = new MandatarioEntities())
            {
                var user = db.Usuarios.Find(id);
                model.Nombre = user.Nombre;
                model.UserName = user.UserName;
                model.Email = user.Email;
                model.Telefono = user.Telefono;
                model.IdUsuario = user.IdUsuario;
            }
            return View(model);
        }



        /// <summary>
        /// Modifica los datos en la base de datos.
        /// Recibe los datos del empleado desde la vista editar.
        /// Busca en la DB un empleado que coincida con su numero de DNi.
        /// Modifica el usuario actualizando los datos enviados como parámetro desde el Formulario.
        /// </summary>
        /// <param name="txtNombre"></param>
        /// <param name="txtApellido"></param>
        /// <param name="txtUserName"></param>
        /// <param name="txtEmail"></param>
        /// <param name="txtTelefono"></param>
        /// <param name="txtIdUsuario"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Editar(string txtNombre,
                                        string txtApellido,
                                        string txtUserName,
                                        string txtEmail,
                                        string txtTelefono,
                                        string txtIdUsuario
                                        )
        {
            try
            {
                //Validaciones del modelo FrmNuevoUsuario
                if (ModelState.IsValid)
                {
                    NuevoUsuarioViewModel modelo = new NuevoUsuarioViewModel();
                    int id = int.Parse(txtIdUsuario);

                    using (MandatarioEntities db = new MandatarioEntities())
                    {
                        var usuario = db.Usuarios.Find(id);
                        usuario.UserName = txtUserName;
                        usuario.Nombre = txtNombre;
                        usuario.Email = txtEmail;
                        usuario.Telefono = txtTelefono;
                        db.SaveChanges();
                    }
                }
                return Redirect("~/Usuarios/");

            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }

        /// <summary>
        /// Recibe los datos del formulario mediante método GET por URL.
        /// Toma el ID que es pasado como parámetro y busca en la DB si existe una entidad.
        /// En caso de que exista lo elimina de la DB y guarda los cambios.
        /// 
        /// /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Eliminar(int id)
        {
            NuevoUsuarioViewModel model = new NuevoUsuarioViewModel();

            using (var db = new MandatarioEntities())
            {
                var user = db.Usuarios.Find(id);
                db.Usuarios.Remove(user);
                db.SaveChanges();
            }

            return Redirect("~/Usuarios/");
        }

    }
}