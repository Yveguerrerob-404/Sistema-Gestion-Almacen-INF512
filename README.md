# Sistema de gestión de productos

Este proyecto es una aplicación de consola desarrollada en C# diseñada para gestionar el inventario de una empresa de forma eficiente. El sistema permite registrar productos, buscarlos por código, eliminarlos y visualizar todo el listado de artículos disponibles.

__Características principales__

-Encapsulamiento: Uso de campos privados y propiedades públicas en la clase Producto para proteger la integridad de los datos.

-Gestión Dinámica: Utiliza List<Producto> para un manejo flexible de la memoria, permitiendo agregar y eliminar artículos sin restricciones de tamaño.

-Validaciones: Implementación de validaciones para evitar códigos duplicados y asegurar que los precios sean valores decimales válidos.

__Estructura del sistema__

El sistema se basa en dos clases principales:

-Producto: Entidad base que almacena la información técnica de cada artículo.

-Almacen: Clase de control que centraliza la lógica de negocio y las operaciones de manipulación de la lista.

__Instrucciones de uso__

Ejecuta la aplicación en tu entorno de desarrollo (Visual Studio o .NET CLI).

Selecciona una opción del menú principal:

1- Registrar Producto: Ingresa los datos del nuevo artículo.

2- Buscar Producto: Localiza un artículo mediante su código único.

3- Eliminar Producto: Remueve un artículo del inventario.

4- Listar Productos: Visualiza el inventario completo y el total de artículos.

5- Salir: Finaliza la sesión.
