using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _04_Data.Data;

namespace _00_Mvc.Controllers
{
    public class EmpleadosMvcController : Controller
    {
        private NorthWindTuneadoDbContext db = new NorthWindTuneadoDbContext();

        // GET: EmpleadosMvc
        public ActionResult Index()
        {
            return View(db.Empleado.ToList());
        }

        //// GET: EmpleadosMvc/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Empleado empleado = db.Empleado.Find(id);
        //    if (empleado == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(empleado);
        //}

        // GET: EmpleadosMvc/Details/5
        //public ActionResult Details(int? id, bool? siguiente)
        //{
        //    if (id == null || siguiente == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Empleado empleado = db.Empleado.Find(id);
        //    if (siguiente.Value==true)
        //    {
        //        //empleado = Algo
        //    }
        //    else
        //    {
        //        //empleado = AlgoDistinto
        //    }
        //    if (empleado == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(empleado);
        //}
        public ActionResult Details(int? id, bool? siguiente)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = null;
            if (siguiente == null)
            {
                empleado = db.Empleado.Where(x => x.EmployeeID == id.Value).FirstOrDefault();
            }
            else
            {
                if (siguiente.Value == true)
                {
                    empleado = db.Empleado.Where(x => x.EmployeeID > id.Value).FirstOrDefault();
                }
                else
                {
                    IList<Empleado> empleados = db.Empleado.Where(x => x.EmployeeID < id.Value).ToList();
                    if (empleados != null && empleados.Count() > 0)
                    {
                        int? idEmpleado = empleados.Max(x => x.EmployeeID);
                        empleado = db.Empleado.Where(x => x.EmployeeID == idEmpleado.Value).FirstOrDefault();
                    }
                }
            }
            if (empleado == null)
            {
                empleado = db.Empleado.Where(x => x.EmployeeID == id.Value).FirstOrDefault();
            }
            return View(empleado);
        }
        public ActionResult DetailsAjax(int? id, bool? siguiente)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = null;
            if (siguiente == null)
            {
                empleado = db.Empleado.Where(x => x.EmployeeID == id.Value).FirstOrDefault();
            }
            else
            {
                if (siguiente.Value == true)
                {
                    empleado = db.Empleado.Where(x => x.EmployeeID > id.Value).FirstOrDefault();
                }
                else
                {
                    IList<Empleado> empleados = db.Empleado.Where(x => x.EmployeeID < id.Value).ToList();
                    if (empleados != null && empleados.Count() > 0)
                    {
                        int? idEmpleado = empleados.Max(x => x.EmployeeID);
                        empleado = db.Empleado.Where(x => x.EmployeeID == idEmpleado.Value).FirstOrDefault();
                    }
                }
            }
            if (empleado == null)
            {
                empleado = db.Empleado.Where(x => x.EmployeeID == id.Value).FirstOrDefault();
            }
            return View(empleado);
        }


        // GET: EmpleadosMvc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadosMvc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,LastName,FirstName,birthDate,Photo,Notes")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        // GET: EmpleadosMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: EmpleadosMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,LastName,FirstName,birthDate,Photo,Notes")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        // GET: EmpleadosMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: EmpleadosMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // POST: Ejercicio/_EmpleadoMvcPartialView/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult _EmpleadoMvcPartialView(Empleado empleado)
        {
            return View("_EmpleadoMvcPartialView", empleado);
        }

        // POST: Ejercicio/_EmpleadoMvcOtraPartialView/5
        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult _EmpleadoMvcOtraPartialView(Empleado empleado)
        {
            return View("_EmpleadoMvcOtraPartialView", empleado);
        }
    }
}
