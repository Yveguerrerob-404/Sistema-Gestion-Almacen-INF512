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
