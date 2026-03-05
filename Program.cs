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
    //aqui tenemos el menú
    class Program
    {
        static Almacen miAlmacen = new Almacen();

        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTIÓN COMERCIAL===");
                Console.WriteLine("1. Registrar Producto");
                Console.WriteLine("2. Buscar Producto");
                Console.WriteLine("3. Eliminar Producto");
                Console.WriteLine("4. Listar Productos");
                Console.WriteLine("5. Salir");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1": Registrar(); break;
                    case "2": Buscar(); break;
                    case "3": Eliminar(); break;
                    case "4": Listar(); break;
                    case "5": salir = true; break;
                }
                if (!salir) { Console.WriteLine("\nPresione una tecla para continuar..."); Console.ReadKey(); }
            }
        }

        static void Registrar()
        {
            Console.WriteLine("\n--- REGISTRO ---");
            Console.Write("Código: "); string cod = Console.ReadLine() ?? "";
            Console.Write("Nombre: "); string nom = Console.ReadLine() ?? "";
            Console.Write("Precio: ");
            
            if (decimal.TryParse(Console.ReadLine(), out decimal pre))
            {
                if (miAlmacen.AgregarProducto(new Producto(cod, nom, pre)))
                    Console.WriteLine("[OK] Registrado con éxito.");
                else 
                    Console.WriteLine("[ERROR] El código ya existe.");
            }
            else Console.WriteLine("[ERROR] Formato de precio incorrecto.");
        }

        static void Buscar()
        {
            Console.Write("\nCódigo a buscar: ");
            string cod = Console.ReadLine() ?? "";
            var p = miAlmacen.BuscarProducto(cod);
            Console.WriteLine(p != null ? p.ToString() : "[!] Producto no encontrado.");
        }

        static void Eliminar()
        {
            Console.Write("\nCódigo a eliminar: ");
            string cod = Console.ReadLine() ?? "";
            if (miAlmacen.EliminarProducto(cod))
                Console.WriteLine("[OK] Producto eliminado.");
            else 
                Console.WriteLine("[!] No se encontró el código.");
        }

        static void Listar()
        {
            var lista = miAlmacen.ObtenerListado();
            if (lista.Count == 0) Console.WriteLine("\nEl almacén está vacío.");
            else
            {
                Console.WriteLine("\n--- INVENTARIO ---");
                lista.ForEach(p => Console.WriteLine(p));
                Console.WriteLine($"\nTotal de productos: {miAlmacen.ObtenerTotal()}");
            }
        }
    }
}
