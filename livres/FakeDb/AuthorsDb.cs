using System;
using System.Collections.Generic;
using livres.Models;
using System.Linq;

namespace livres.FakeDb
{
    public static class AuthorsDb
    {
        public static List<Author> authors { get; set; } = new List<Author>();

        private static int _currentId = 0;

        //Create


        public static void Add(Author a)
        {
            a.Id = ++_currentId;
            authors.Add(a);
        }


        //Retrieve by Id

        public static Author GetById(int id)
        {
            Author AuthorFound = authors.FirstOrDefault(a => a.Id == id);
            return AuthorFound;


            //same as foreach --> FirstOrDEfault
        }


        //Retrieve by name

        public static Author GetByName(string name)
        {
            Author AuthorFound = authors.FirstOrDefault(a => a.Name == name);
            return AuthorFound;

            //same as foreach --> FirstOrDEfault

            
        }


        // retrieve the whole list

        public static List<Author> GetAll()
        {
            return authors;
        }

        //Delete

        public static void Delete(int id)
        {
            //First calling the method to retrieve the item to delete
            Author toDel = GetById(id);
            authors.Remove(toDel);
        }



        //Update

        public static void Update(Author a)
        {
            Delete(a.Id);
            Add(a);


            //btw why not taing (Update(int id) and then do same as in Delete method
        }
    }
}

