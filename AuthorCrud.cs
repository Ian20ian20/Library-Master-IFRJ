using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Service;

namespace View
{
    public class AuthorGrud
    {
        public AuthorGrud()
        {
        }

        public void TestGetById()
        {
            AuthorService AuthorService = new AuthorService();
            ShowAuthor(AuthorService.GetAuthorById(1));
            Console.ReadKey();
        }

        private void ShowAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public void TestGetAll()
        {
            AuthorService AuthorService = new AuthorService();

            foreach (var Author in AuthorService.GetAllAuthors())
            {
                ShowAuthor(Author);
                Console.WriteLine("___________");
            }

            Console.ReadKey();
        }

        private void ShowAuthor(object author)
        {
            throw new NotImplementedException();
        }

        private void TestAdd(Author Author)
        {
            BookService AuthorService = new AuthorService();
            IEnumerable<string> errors = AuthorService.AuthorBook(Author);

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
            }
            else
            {
                Console.WriteLine("Autor adicionado com sucesso");
            }

            Console.ReadKey();
        }

        public void TestAdd()
        {
            var Author = new Author("Gabriela") { Id = 3 };

            TestAdd(Author);
        }

        public void TestUpdate()
        {
            var Author = new Author("Gabriela") { Id = 3 };


            TestAdd(Author);
        }

        public void TestRemove()
        {
            var Author = new Author("Gabriela") { Id = 3 };
            AuthorService AuthorService = new AuthorService();
            AuthorService.RemoveAuthor(Author.Id);

            Console.WriteLine("Autor removido.");
            Console.ReadKey();
        }

        public static void ShowAuthors(Author Author)
        {
            Console.WriteLine($"Name: {Author.Name}");

            Console.WriteLine("Autores:");
            foreach (var book in Author.GetBooks())
            {
                Console.WriteLine($"- {Author}");
            }

            }
        }
    }
