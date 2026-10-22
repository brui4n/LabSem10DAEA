using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabSem10DAEA.Models;

namespace LabSem10DAEA.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            if (Session["productos"] == null)
            {
                List<ProductoModel> productosIniciales = new List<ProductoModel>
                {
                    new ProductoModel { Id = 1, Nombre = "Laptop Lenovo IdeaPad", Descripcion = "Intel Core i5, 16GB RAM, 512GB SSD", Precio = 2499.00m, Stock = 10 },
                    new ProductoModel { Id = 2, Nombre = "Mouse Inalámbrico Logitech", Descripcion = "Sensor óptico 1000 DPI, receptor USB", Precio = 59.90m, Stock = 35 },
                    new ProductoModel { Id = 3, Nombre = "Monitor Samsung 24''", Descripcion = "Full HD IPS 75Hz con FreeSync", Precio = 489.00m, Stock = 15 }
                };
                Session["productos"] = productosIniciales;
            }

            return View((List<ProductoModel>)Session["productos"]);
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            var productos = Session["productos"] as List<ProductoModel>;
            if (productos == null)
            {
                return RedirectToAction("Index");
            }

            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return HttpNotFound();
            }

            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(ProductoModel producto)
        {
            try
            {
                var productos = Session["productos"] as List<ProductoModel>;
                if (productos == null)
                {
                    productos = new List<ProductoModel>();
                    Session["productos"] = productos;
                }

                // Autogenerar Id automáticamente
                producto.Id = productos.Any() ? productos.Max(p => p.Id) + 1 : 1;

                productos.Add(producto);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(producto);
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            var productos = Session["productos"] as List<ProductoModel>;
            if (productos == null)
            {
                return RedirectToAction("Index");
            }

            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return HttpNotFound();
            }

            return View(producto);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductoModel producto)
        {
            try
            {
                var productos = Session["productos"] as List<ProductoModel>;
                if (productos != null)
                {
                    var prodExistente = productos.FirstOrDefault(p => p.Id == id);
                    if (prodExistente != null)
                    {
                        prodExistente.Nombre = producto.Nombre;
                        prodExistente.Descripcion = producto.Descripcion;
                        prodExistente.Precio = producto.Precio;
                        prodExistente.Stock = producto.Stock;
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(producto);
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            var productos = Session["productos"] as List<ProductoModel>;
            if (productos == null)
            {
                return RedirectToAction("Index");
            }

            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return HttpNotFound();
            }

            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var productos = Session["productos"] as List<ProductoModel>;
                if (productos != null)
                {
                    var producto = productos.FirstOrDefault(p => p.Id == id);
                    if (producto != null)
                    {
                        productos.Remove(producto);
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
