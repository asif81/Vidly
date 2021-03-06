﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;


namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customer
  
        public ActionResult Index()
        {
            if (User.IsInRole(RoleNames.CanManageMovies))
            {
                return View("List");
            }
            return View("ReadOnlyList");
        }

        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(m => m.MembershipType).SingleOrDefault(c => c.CustomerId == Id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new ViewModels.CustomerFormViewModel()
            {                
                MembershipType = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var membershipTypes = _context.MembershipTypes.ToList();
                var viewModel = new ViewModels.CustomerFormViewModel(customer)
                {
                    MembershipType = membershipTypes
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.CustomerId == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var CustomerInDb = _context.Customers.Single(c => c.CustomerId == customer.CustomerId);

                CustomerInDb.BirthDate = customer.BirthDate;
                CustomerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                CustomerInDb.MembershipTypeId = customer.MembershipTypeId;
                CustomerInDb.Name = customer.Name;
            }

            _context.SaveChanges();
            return RedirectToAction("Index","Customer");
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(m => m.MembershipType).SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new ViewModels.CustomerFormViewModel(customer)
            {                
                MembershipType = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}