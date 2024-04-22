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
                    FirstName = "Name 1",
                    LastName = "Surname 1",
                    Email = "person1@tuks.co.za",

                });
                people.Add(new Models.PersonModel
                {
                    StuNumber = "u0002",
                    FirstName = "Name 2",
                    LastName = "Surname 2",
                    Email = "person2@tuks.co.za",

                });
                people.Add(new Models.PersonModel
                {
                    StuNumber = "u0003",
                    FirstName = "Name 3",
                    LastName = "Surname 3",
                    Email = "person3@tuks.co.za",

                });
                people.Add(new Models.PersonModel
                {
                    StuNumber = "u0004",
                    FirstName = "Name 4",
                    LastName = "Surname 4",
                    Email = "person4@tuks.co.za",

                });
                people.Add(new Models.PersonModel
                {
                    StuNumber = "u0005",
                    FirstName = "Name 5",
                    LastName = "Surname 5",
                    Email = "person5@tuks.co.za",

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