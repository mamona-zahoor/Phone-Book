using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            List<Person> p = db.People.ToList();
            List<PersonModel> M = new List<PersonModel>();
            foreach (Person per in p)
            {
                PersonModel obj = new PersonModel();

                obj.DateOfBirth = per.DateOfBirth;
                obj.EmailId = per.EmailId;
                obj.FirstName = per.FirstName;
                obj.MiddleName = per.MiddleName;
                obj.LastName = per.LastName;
                obj.LinkedInId = per.LinkedInId;
                obj.HomeCity = per.HomeCity;
                obj.FaceBookAccountId = per.FaceBookAccountId;
                obj.HomeAddress = per.HomeAddress;
                obj.ImagePath = per.ImagePath;
                obj.TwitterId = per.TwitterId;

                M.Add(obj);



            }
            return View(M);
            db.SaveChanges();
            return View();
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
                p.FaceBookAccountId = obj.FaceBookAccountId;
                p.LinkedInId = obj.LinkedInId;
                p.ImagePath = obj.ImagePath;
                p.TwitterId = obj.TwitterId;
                p.EmailId = obj.EmailId;
                p.AddedBy = User.Identity.GetUserId();
                p.AddedOn = DateTime.Now;
                p.UpdateOn = DateTime.Now;


                PhoneBookDbEntities db = new PhoneBookDbEntities();
                db.People.Add(p);
                db.SaveChanges();

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            PersonModel m = new PersonModel();
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            foreach (Person p in db.People)
            {
                
                if (p.PersonId == id)
                {
                    m.FirstName = p.FirstName;
                    m.MiddleName = p.MiddleName;
                    m.LastName = p.LastName;
                    m.DateOfBirth = p.DateOfBirth;
                    m.HomeAddress = p.HomeAddress;
                    m.HomeCity = p.HomeCity;
                    m.FaceBookAccountId = p.FaceBookAccountId;
                    m.LinkedInId = p.LinkedInId;
                    m.ImagePath = p.ImagePath;
                    m.TwitterId = p.TwitterId;
                    m.EmailId = p.EmailId;
                    break;
                }
            }

            return View(m);

        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonModel obj)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();

                db.People.Find(id).FirstName = obj.FirstName;
                db.People.Find(id).MiddleName = obj.MiddleName;
                db.People.Find(id).LastName = obj.LastName;
                db.People.Find(id).DateOfBirth = obj.DateOfBirth;
                db.People.Find(id).HomeAddress = obj.HomeAddress;
                db.People.Find(id).HomeCity = obj.HomeCity;
                db.People.Find(id).FaceBookAccountId = obj.FaceBookAccountId;
                db.People.Find(id).LinkedInId = obj.LinkedInId;
                db.People.Find(id).TwitterId = obj.TwitterId;
                db.People.Find(id).EmailId = obj.EmailId;
                db.People.Find(id).UpdateOn = DateTime.Now;
                db.People.Find(id).ImagePath = obj.ImagePath;

                db.SaveChanges();

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
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            Person myperson = new Person();
            foreach (Person p in db.People)
            {
                if (p.PersonId == id)
                {
                    myperson = p;
                    break;
                }
            }
            db.People.Remove(myperson);
            db.SaveChanges();
            return View("Index","Person");
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
