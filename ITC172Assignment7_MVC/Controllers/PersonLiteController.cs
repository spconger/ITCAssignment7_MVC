﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITC172Assignment7_MVC.Models;

namespace ITC172Assignment7_MVC.Controllers
{
    public class PersonLiteController : Controller
    {
        Community_AssistEntities db = new Community_AssistEntities();
        // GET: PersonLite
        public ActionResult Index()
        {
            var peeps = from p in db.People
                        from a in p.PersonAddresses
                        from c in p.Contacts
                        where c.ContactTypeKey == 1
                        select new
                        {
                            p.PersonLastName,
                            p.PersonFirstName,
                            p.PersonEmail,
                            a.PersonAddressApt,
                            a.PersonAddressStreet,
                            a.PersonAddressCity,
                            a.PersonAddressState,
                            a.PersonAddressZip,
                            c.ContactNumber
                        };
            List<PersonLite> people = new List<PersonLite>();
            foreach(var pers in peeps)
            {
                PersonLite pl = new PersonLite();
                pl.LastName = pers.PersonLastName;
                pl.FirstName = pers.PersonFirstName;
                pl.Email = pers.PersonEmail;
                pl.Apartment = pers.PersonAddressApt;
                pl.Street = pers.PersonAddressStreet;
                pl.City = pers.PersonAddressCity;
                pl.State = pers.PersonAddressState;
                pl.ZipCode = pers.PersonAddressZip;
                pl.HomePhone = pers.ContactNumber;
                people.Add(pl);
            }

            return View(people);
        }
    }
}