using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Persistence.BD;
using Persistence.BD.Repositories;
using System;

namespace Service
{
    public class BookService
    {
        public IEnumerable<Book> GetAllBooks()
        {
            IEnumerable<Book> books;
            using (UnityOfWork unity = new UnityOfWork())
            {
                books = new BookBdRepository(unity).GetAll();
                var subjectRep = new SubjectBdRepository(unity);
                var authorRep = new AuthorBdRepository(unity);
                foreach (var book in books)
                {
                    book.AddSubjects(subjectRep.GetSubjectsOfABook(book));
                    book.AddAuthors(authorRep.GetAuthorsOfABook(book));
                }

                unity.Complete();
            }

            return books;
        }

        public Book GetBookById(object id)
        {
            Book book = null;

            using (var unity = new UnityOfWork())
            {
                book = new BookBdRepository(unity).GetById(id);

                unity.Complete();
            }

            return book;

        }

        public IEnumerable<string> AuthorBook(Author author)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> AddBook(Book book)
        {
            IEnumerable<string> errors = book.Validate();

            if (!errors.Any())
            {
                using (var unity = new UnityOfWork())
                {
                    new BookBdRepository(unity).Add(book);
                    unity.Complete();
                }
            }

            return errors;
        }

        public void RemoveBook(int bookId)
        {
            using (var unity = new UnityOfWork())
            {
                new BookBdRepository(unity).Remove(new Book(){Id= bookId});
                unity.Complete();
            }
        }

        public static implicit operator BookService(AuthorService v)
        {
            throw new NotImplementedException();
        }

        public void RemoveBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
