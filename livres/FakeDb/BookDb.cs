using System;
using System.Collections.Generic;
using System.Linq;
using livres.Models;

namespace livres.FakeDb
{
    public static class BookDb
    {
        //if no new is instat,tiated the list doesnt exist
        public static List<Livre> livres{ get; set; } = new List<Livre>();


        private static int _currentID = 0;


        //Create

        public static void Add (Livre l)
        {
            l.Id = ++_currentID;
            livres.Add(l);
        }


        //Read
        public static Livre GetById(int id)
        {
            Livre liv = livres.FirstOrDefault(l => l.Id == id);
            return liv;
        }

        // Read ALL
        public static List<Livre> GetAll() //returns a list!
        {
            return livres;
        }

        //Update

        public static void Update(Livre l)
        {
            //why not retrieving book to update by id but passing Live l as param?
            //why not Delete(l.Id) ??;
            livres.Remove(l);
            //in fact above livre.Id will be a number which is required for the method Delete to remove a book
            Add(l);
            //why not livres.Add(l) ?? bc otherwise we wont generate id !
        }

        //Delete


        public static void Delete(int id)
        {
            Livre todel = GetById(id);
            livres.Remove(todel);
        }
    }
}

