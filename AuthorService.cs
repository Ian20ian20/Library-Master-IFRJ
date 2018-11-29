using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Persistence.BD;
using Persistence.BD.Repositories;
using System;

namespace Service
{
    public class AuthorService
    {
        public IEnumerable<Author> GetAllAuthor()
        {
            IEnumerable<Author> Author;
            using (UnityOfWork unity = new UnityOfWork())
            {
                Author = new AuthorBdRepository(unity).GetAll();
                var subjectRep = new SubjectBdRepository(unity);
                var authorRep = new AuthorBdRepository(unity);
                foreach (var Authors in Author)
                {
                    Authors.AddName(subjectRep.GetSNameOfAuthors(Author));
                    Authors.AddAuthors(authorRep.GetAuthorsOfAuthor(Author));
                }

                unity.Complete();
            }

            return Author;
        }

        public IEnumerable<object> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public Author GetAuthorById(object id)
        {
            Author Author = null;

            using (var unity = new UnityOfWork())
            {
                Author = new AuthorBdRepository(unity).GetById(id);
                Author.AddName(new SubjectBdRepository(unity).GetNameOfAuthor(Author));

                unity.Complete();
            }

            return Author;

        }

        public IEnumerable<string> AddAuthor(Author Author)
        {
            IEnumerable<string> errors = Author.Validate();

            if (!errors.Any())
            {
                using (var unity = new UnityOfWork())
                {
                    new AuthorBdRepository(unity).Add(Author);
                    unity.Complete();
                }
            }

            return errors;
        }

        public void RemoveAuthor(Author Author)
        {
            using (var unity = new UnityOfWork())
            {
                new AuthorBdRepository(unity).Remove(Author);
                unity.Complete();
            }
        }

        public void RemoveAuthor(int id)
        {
            throw new NotImplementedException();
        }
    }
}