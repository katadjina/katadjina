using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livres.FakeDb;
using livres.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace livres.Controllers
{
    public class BookController : Controller
    {
        // displays the book list
        public IActionResult Index()
        {
            return View(BookDb.GetAll());
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }



        //if form data is submitted
        [HttpPost]
        public IActionResult Create(Livre form)
        {

            if (ModelState.IsValid)
            {
                Livre newL = new Livre
                {
                    Title = form.Title,
                    ISBN = form.ISBN,
                    idAuthor  = form.idAuthor

                };
                BookDb.Add(newL);
                return RedirectToAction("index");
            }
            else
            {
                //not sure why form is passed as param
                return View(form);
            }
        }


        public IActionResult Details(int id)
        {
            Author a = AuthorsDb.GetById(id);
            return View(a);
        }







    }



}

