using DemoBooks.services;
using DemoBooks.utils;

//While para que el programa se ejecute hasta que el usuario decida salir
while (true)
{
    //Limpia la consola despues de cada llamado y muestra el encabezado y opciones
    Console.Clear();

    //Recupera la opcion seleccionada por el usuario
    int? opcion = Options();

    //Convierte el numero de opcion al enum OptionsEnum que lo definimos en el archivo utils/OptionsEnum.cs
    OptionEnum optionEnum = (OptionEnum)opcion;

    if (opcion == 6)
    {
        return;
    }

    //switch con cada opcion llamando a su respectivo metodo
    string message = optionEnum switch
    {
        OptionEnum.Add => BookService.AddBook(),
        OptionEnum.Update => BookService.UpdateBook(),
        OptionEnum.Delete => BookService.Eliminar(),
        OptionEnum.Get => BookService.GetAll(),
        OptionEnum.GetByName => BookService.BuscarPorNombre(),
        OptionEnum.Exit => "Salir",
        _ => "Opcion no valida"
    };

    //imprime el mensaje de respuesta obtenido de cada metodo
    Console.WriteLine(message);
    Console.ReadLine();
}

//Método para mostrar el encabezado del menú
static int? Options()
{
    Console.WriteLine("Bienvenido al Bootcamp");
    Console.WriteLine("1. Crear Libro");
    Console.WriteLine("2. Editar un Libro");
    Console.WriteLine("3. Eliminar un Libro");
    Console.WriteLine("4. Obtener Listado de Libros");
    Console.WriteLine("5. Obtener libro por el nombre");
    Console.WriteLine("6. Salir");

    var opcion = Console.ReadLine();
    return int.Parse(opcion);
}