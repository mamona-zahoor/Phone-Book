using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            List<Person> p = db.People.ToList();
            List<PersonModel> M = new List<PersonModel>();
            foreach(Person per in p)
            {
                PersonModel obj = new PersonModel();
                obj.DateOfBirth = per.DateOfBirth;
                obj.EmailId = per.EmailId;
                obj.FirstName = per.FirstName;
                obj.MiddleName = per.MiddleName;
                obj.LastName = per.LastName;
                obj.LinkedInId = per.LinkedInId;
                obj.HomeCity = per.HomeCity;
                obj.FacebookAccountId = per.FaceBookAccountId;
                obj.HomeAddress = per.HomeAddress;
                obj.ImagePath = per.ImagePath;
                obj.TwitterId = per.TwitterId;
                M.Add(obj);
                
            }
           
            return View(M);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonModel obj)
        {
            
            try
            {
                Person p = new Person();
                p.FirstName = obj.FirstName;
                p.MiddleName = obj.MiddleName;
                p.LastName = obj.LastName;
                p.DateOfBirth = obj.DateOfBirth;
                p.HomeAddress = obj.HomeAddress;
                p.HomeCity = obj.HomeCity;
                p.FaceBookAccountId = obj.FacebookAccountId;
                p.LinkedInId = obj.LinkedInId;
                p.ImagePath = obj.ImagePath;
                p.TwitterId = obj.TwitterId;
                p.AddedBy = User.Identity.Name;
                p.AddedOn = DateTime.Now;
                p.UpdateOn = DateTime.Now;
                // TODO: Add insert logic here
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                db.People.Add(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
