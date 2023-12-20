using DemoBooks.entities;
using System.Text;

namespace DemoBooks.services
{
    public static class BookService
    {
        public static List<Book> books = new List<Book>();

        //Método para crear un libro, este método es llamado desde el Program.cs
        public static string AddBook()
        {
            //Ingreso de datos por consola
            Console.WriteLine("AddBook");
            Console.WriteLine("Ingrese el titulo del libro");
            string title = Console.ReadLine();
            Console.WriteLine("Ingrese el autor del libro");
            string author = Console.ReadLine();
            Console.WriteLine("Ingrese la categoria del libro");
            string category = Console.ReadLine();

            // Crear un nuevo libro con la información ingresada por consola
            var book = new Book
            {
                Id = books.Count + 1,
                Title = title,
                Author = author,
                Category = category,
                IsAvailable = true
            };

            // Agregar el libro a la lista de libros
            books.Add(book);

            return $"El libro {book.Title} ha sido agregado correctamente";

        }




        //Método para actualizar un libro llamado desde el Program.cs
        public static string UpdateBook()
        {
            //ingreso de datos por consola
            Console.WriteLine("Actualizar Libro");

            Console.WriteLine("Ingrese el Id del libro");
            int id = Convert.ToInt16(Console.ReadLine());

            var book = books.FirstOrDefault(x => x.Id == id);

            //Validar si el libro existe
            if (book == null)
            {
                return $"El libro con Id {id} no existe";
            }

            Console.WriteLine("Ingrese el titulo del libro");
            string title = Console.ReadLine();
            Console.WriteLine("Ingrese el autor del libro");
            string author = Console.ReadLine();
            Console.WriteLine("Ingrese la categoria del libro");
            string category = Console.ReadLine();

            //Buscar el libro por el id ingresado, dentro de la lista de libros


            //Actualizar los datos del libro
            book.Title = title;
            book.Author = author;
            book.Category = category;

            return $"El libro con el id {book.Id} ha sido actualizado correctamente";
        }

        // Metodo para Elimina un libro

        public static string Eliminar()
        {
            Console.WriteLine("Eliminar Libro");

            Console.WriteLine("Ingrese el id del libro: ");
            int id = int.Parse(Console.ReadLine());

            Book book = books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return $"No existe un libro con el id {id}";
            }

            string eliminar;
            do
            {
                Console.WriteLine("Está seguro de eliminar este libro? (Si - S, No - N) ");
                eliminar = Console.ReadLine();

            } while (eliminar != 'S'.ToString() && eliminar != 'N'.ToString());

            if (eliminar == 'S'.ToString())
            {
                Console.WriteLine("Id: " + book.Id);
                Console.WriteLine("Titulo: " + book.Title);
                Console.WriteLine("Autor: " + book.Author);
                Console.WriteLine("Categoria: " + book.Category);
                books.RemoveAt(id - 1);
                return "Libro eliminado correctamente!";
            }
            else
            {
                return "Usted ha decidido no eliminar el libro";
            }








        }

        //Método para listar todos los libros llamado desde el Program.cs
        public static string GetAll()
        {
            string message = string.Empty;
            Console.WriteLine("Listado de Libros");

            //Validar si existen libros en la lista
            if (books == null)
                message = "No hay libros disponibles";


            //Armar la lista de libros en formato string
            var builder = new StringBuilder();
            builder.AppendLine("|ID".PadRight(10) + "|Título".PadRight(20) + "|Autor".PadRight(20) + "|Categoría".PadRight(20) + "|Disponible".PadRight(10));
            foreach (var book in books)
            {
                builder.AppendLine($"|{book.Id.ToString().PadRight(9)}|{book.Title.PadRight(19)}|{book.Author.PadRight(19)}|{book.Category.PadRight(19)}|{(book.IsAvailable ? "Sí" : "No").PadRight(9)}");

            }
            return builder.ToString();
        }

        public static string BuscarPorNombre()
        {
            Console.WriteLine("Búsqueda del libro por título");

            Console.WriteLine("Ingrese el nombre del libro");
            string name = Console.ReadLine();

            Book book = books.Find(x => x.Title == name);
            if (book == null)
            {
                return $"No existe un libro con el nombre {name}";
            }
            // prueba commitcdf

            string message = $"Libro: {book.Title}\nAutor: {book.Author}\n Categoria: {book.Category}\n Disponibilidad: {book.IsAvailable}\n";

            return message;

        }
    }
}
