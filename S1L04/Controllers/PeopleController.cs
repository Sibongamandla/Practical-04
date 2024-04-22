using S1L04.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace S1L04.Controllers
{
    public class PeopleController : Controller
    {
       //static list to hold people data
       private static List<Models.PersonModel> people = new List<Models.PersonModel>();
        public ActionResult ListPeople()
        {
            if (!people.Any())
            {
                people.Add(new Models.PersonModel
                {
                    StuNumber = "u0001",
                    FirstName = "Big",
                    LastName = "Bop",
                    Email = "BigBop@it.com",

                });
                people.Add(new Models.PersonModel
                {
                    StuNumber = "u0002",
                    FirstName = "Im",
                    LastName = "Him",
                    Email = "ImHim@it.com",

                });
                people.Add(new Models.PersonModel
                {
                    StuNumber = "u0003",
                    FirstName = "I",
                    LastName = "Am",
                    Email = "IAm@it.com",

                });
                people.Add(new Models.PersonModel
                {
                    StuNumber = "u0004",
                    FirstName = "Side",
                    LastName = "Piece",
                    Email = "sidePiece@it.com",

                });
                people.Add(new Models.PersonModel
                {
                    StuNumber = "u0005",
                    FirstName = "Love",
                    LastName = "Him",
                    Email = "LoveH@it.com",

                });


                // Reorder the list so that he new perosn appears at the bottom or in order
                people = people.OrderBy(p => p.StuNumber).ToList();
            }
            return View(people);


        }

        public ActionResult Person01()
        {

            return View();
        }

        public ActionResult CreatePerson()
        {
            return View();
        }

      

        [HttpPost]
        public ActionResult CreatePerson(PersonModel person)
        {
        

            if (ModelState.IsValid)
            {
                //add the new person  to the existing list
                people.Add(person);         

                // Redirect to the list of people after successful creation
                return RedirectToAction("ListPeople");
            }

            // If model state is not valid, return the view with validation errors
            return View(person);
        }
    }

}