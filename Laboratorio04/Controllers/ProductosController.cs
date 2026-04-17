using Microsoft.AspNetCore.Mvc;
using Laboratorio04.Models;

namespace Laboratorio04.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ProductoRepositorio _repositorio;

        public ProductosController()
        {
            _repositorio = new ProductoRepositorio();
        }

        // GET: Productos
        public IActionResult Index()
        {
            var productos = _repositorio.ObtenerTodos();
            return View(productos);
        }

        // GET: Productos/Detalles
        public IActionResult Detalles(int id)
        {
            var producto = _repositorio.ObtenerPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // GET: Productos/Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Productos/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Agregar(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productos/Editar
        public IActionResult Editar(int id)
        {
            var producto = _repositorio.ObtenerPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productos/Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repositorio.Actualizar(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productos/Eliminar
        public IActionResult Eliminar(int id)
        {
            var producto = _repositorio.ObtenerPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productos/Eliminar
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarEliminar(int id)
        {
            _repositorio.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
