using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using livres.FakeDb;
using livres.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace livres.Controllers
{
    public class AuthorController : Controller
    {
        // GET: /<controller>/
        //index page will show all the authors
        public IActionResult Index()
        {
            return View(AuthorsDb.GetAll());
            //you need to send as parameter the whole list
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        //if form data is submitted
        [HttpPost]     
        public IActionResult Create(Author form)
        {
            bool exists = false;
            if (ModelState.IsValid)
            {
                Author newA = new Author
                {
                    Name = form.Name,
                    BirthDate = form.BirthDate
                   
                };

                //check if the author already exists to avoid duplicates
                //doesnt work well
                
                foreach (Author a in AuthorsDb.authors)
                {
                    if (newA.Name == a.Name)
                    {
                        exists = true;
                       // Console.WriteLine(newA.Name);
                    }
                    else
                    {
                        exists = false;
                    }
                }


                if (exists == false)
                {
                    AuthorsDb.Add(newA);
                    return RedirectToAction("index");
                }
                else
                {
                   
                    return RedirectToAction("authorExists");
                }



            }

            else
            {
                //not sure why form is passed as param
                return View(form);
            }
        }


        public IActionResult Details(int id)
        {
            //like this we can have prefilled forms to see what data we are editing
            Author a = AuthorsDb.GetById(id);
            return View(a);
        }


        public IActionResult AuthorExists()
        {
            return View();
        }




        //2 updates for viewing and retrieving form data


        [HttpGet]
        public IActionResult Update(int id)
        {
            //like this we can have prefilled forms to see what data we are editing
            Author a = AuthorsDb.GetById(id);
            return View(a);
        }


        //not working -> new is added instead//idk how to get old author id so when Update method is called -> 
        [HttpPost]
        public IActionResult Update(Author form)
        {
            if(ModelState.IsValid)
            {
                Author updatedA = new Author
                {
                    Name = form.Name,
                    BirthDate = form.BirthDate

                };              
               
                 AuthorsDb.Update(updatedA);
                 return RedirectToAction("index");
             }
                

            else
            {
                //why form is passed as param
                return View(form);
            }
        }





        public IActionResult Delete(int id)
        {
            AuthorsDb.Delete(id);
            return RedirectToAction("index");

        }

    }

}


