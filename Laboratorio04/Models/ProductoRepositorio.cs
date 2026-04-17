namespace Laboratorio04.Models
{
    public class ProductoRepositorio
    {
        private static readonly List<Producto> _productos = new();

        private static int _siguienteId = 1;

        public List<Producto> ObtenerTodos()
        {
            return _productos;
        }

        public Producto? ObtenerPorId(int id)
        {
            return _productos.FirstOrDefault(producto => producto.Id == id);
        }

        public void Agregar(Producto producto)
        {
            producto.Id = _siguienteId++;
            _productos.Add(producto);
        }

        public void Actualizar(Producto producto)
        {
            var productoExistente = ObtenerPorId(producto.Id);
            if (productoExistente != null)
            {
                productoExistente.Nombre = producto.Nombre;
                productoExistente.Precio = producto.Precio;
                productoExistente.Categoria = producto.Categoria;
            }
        }

        public void Eliminar(int id)
        {
            var producto = ObtenerPorId(id);
            if (producto != null)
            {
                _productos.Remove(producto);
            }
        }
    }
}
