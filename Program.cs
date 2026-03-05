using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestionComercial
{
    // clase entidad
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Producto(string codigo, string nombre, decimal precio)
        {
            Codigo = codigo ?? "";
            Nombre = nombre ?? "";
            Precio = precio;
        }

        public override string ToString()
        {
            return $"CÓDIGO: {Codigo.PadRight(10)} | NOMBRE: {Nombre.PadRight(15)} | PRECIO: RD${Precio:N2}";
        }
    }
     // clase de logica del negocio
        public class Almacen
    {
        // utilizamos List<Producto> 
        private List<Producto> productos = new List<Producto>();

        public bool AgregarProducto(Producto nuevo)
        {
            // Evitar códigos duplicados (Requisito obligatorio)
            if (productos.Any(p => p.Codigo.Equals(nuevo.Codigo, StringComparison.OrdinalIgnoreCase)))
                return false;

            productos.Add(nuevo);
            return true;
        }

        public Producto? BuscarProducto(string codigo)
        {
            return productos.FirstOrDefault(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        }

        public bool EliminarProducto(string codigo)
        {
            var p = BuscarProducto(codigo);
            if (p != null) return productos.Remove(p);
            return false;
        }

        public List<Producto> ObtenerListado() => productos;

        public int ObtenerTotal() => productos.Count;
    }
