using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cor;
using static WebClientes.Models.Enum;

namespace WebClientes.Controllers
{
    public class ClienteController : Controller
    {
        public void Alert(string message, NotificationType notificationType)
        {
            var msg = "<script language='javascript'>Swal.fire('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "</script>";
            //var msg = "<script language='javascript'>Swal.fire({title:'',text: '" + message + "',type:'" + notificationType + "',allowOutsideClick: false,allowEscapeKey: false,allowEnterKey: false})" + "</script>";
            TempData["notification"] = msg;
        }

        public void Message(string message, NotificationType notifyType)
        {
            TempData["Notification2"] = message;

            switch (notifyType)
            {
                case NotificationType.success:
                    TempData["NotificationCSS"] = "alert-box success";
                    break;
                case NotificationType.error:
                    TempData["NotificationCSS"] = "alert-box errors";
                    break;
                case NotificationType.warning:
                    TempData["NotificationCSS"] = "alert-box warning";
                    break;

                case NotificationType.info:
                    TempData["NotificationCSS"] = "alert-box notice";
                    break;
            }
        }
        Dclientes Dcliente = new Dclientes();
        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = Dcliente.listaClientes();
            return View(cliente);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(clientes cliente)
        {
            try
            {
                
                Dcliente.AgregarCliente(cliente);              
                Alert("Cliente Guardado", NotificationType.success);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return HttpNotFound();

            }
        }

        public ActionResult Editar(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = Dcliente.DetalleCliente(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }

            return View(clientes);


        }

        [HttpPost]
        public ActionResult Editar(clientes cliente)
        {
            try
            {
                Dcliente.EditarCliente(cliente);
                Alert("Cliente Modificado", NotificationType.success);
                return RedirectToAction("Index");
                return View(cliente);
            }
            catch (Exception ex)
            {
                return HttpNotFound();

            }
        }

        public RedirectToRouteResult listadoTarjetas(int id)
        {
            TempData["ID"] = id;
            return RedirectToAction("ListadoTarjetas/" + id, "Tarjeta");
        }

    }
}