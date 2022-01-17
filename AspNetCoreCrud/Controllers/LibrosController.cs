using AspNetCoreCrud.Data;
using AspNetCoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCrud.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;

        }

        //Http Get Index
        public IActionResult Index()
        {
            IEnumerable<Libro> ListLibros = _context.Libro;

            return View(ListLibros);
        }

        //Http Get CREATE
        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Http Post CREATE
        public IActionResult Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Add(libro);
                _context.SaveChanges();

                TempData["mensaje"] = "El libro se ha guardado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //Http Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtener el libro

            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }


            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Http Post Edit
        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Update(libro);
                _context.SaveChanges();

                TempData["mensaje"] = "El libro se ha actualizado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //Http Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtener el libro

            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }


            return View(libro);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //Http Post Delete
        public IActionResult DeleteLibro(int? id)
        {

            //Obtener el libro por id

            var libro = _context.Libro.Find(id);

            if (libro == null)
            {

                return NotFound();

            }

            _context.Libro.Remove(libro);
            _context.SaveChanges();

            TempData["mensaje"] = "El libro se ha Eliminado correctamente";
            return RedirectToAction("Index");

        }
    }

}
