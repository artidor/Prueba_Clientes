using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cor;
using Cor.Models;
using static WebClientes.Models.Enum;


namespace WebClientes.Controllers
{
    public class TarjetaController : Controller
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

        DTarjetas Dtarjetas = new DTarjetas();
        Dclientes Dcliente = new Dclientes();

        // GET: Tarjeta
        public ActionResult ListadoTarjetas(int id)
        {
           
            var tarjeta = Dtarjetas.listaTarjetas(id);
            return View(tarjeta);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Tarjeta tarjeta)
        {
            try
            {
                tarjeta.codCliente = Convert.ToInt32(TempData["ID"]);

                List<Tarjeta> valor= Dtarjetas.DetalleTarjetaPorNumero(tarjeta.Numero);
              
                if (valor.Count > 0)
                {


                    Alert("El numero de cuenta ya existe", NotificationType.error);                   
                    return RedirectToAction("Crear");

                }
                else
                {
                    Dtarjetas.AgregarTarjeta(tarjeta);
                    Alert("Tarjeta Guardada", NotificationType.success);
                    return RedirectToAction("ListadoTarjetas/" + tarjeta.codCliente);
                    return View(tarjeta);                   
                }
                 
             
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
            Tarjeta tarjeta = Dtarjetas.DetalleTarjeta(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }

            return View(tarjeta);


        }

        [HttpPost]
        public ActionResult Editar(Tarjeta tarjeta)
        {
            try
            {
                List<Tarjeta> valor = Dtarjetas.DetalleTarjetaPorNumero(tarjeta.Numero);
                if (valor.Count > 0)
                {
                    Alert("El numero de cuenta ya existe", NotificationType.error);
                    return RedirectToAction("ListadoTarjetas/" + Convert.ToInt32(TempData["ID"]));
                }
                else 
                {
                    Dtarjetas.EditarTarjeta(tarjeta);
                    Alert("Tarjeta Modificada", NotificationType.success);
                    return RedirectToAction("ListadoTarjetas/" + Convert.ToInt32(TempData["ID"]));
                    return View(tarjeta);
                }



               
            }
            catch (Exception ex)
            {
                return HttpNotFound();

            }
        }
    }
}