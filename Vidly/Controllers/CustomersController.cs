﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        [Route("Customers/Details")]
        [Route("Customers/Details/{id}")]
        public ActionResult Detail(int? id)
        {
            var customer = _context.Customer.Include(c => c.membershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult Index()
        {
            var customers = _context.Customer.Include(c => c.membershipType).ToList();
            return View(customers);
        }

        public ActionResult New()
        {
            var membershipType = _context.membershipTypes.ToList();
            NewCustomerViewmodel newModel = new NewCustomerViewmodel()
            {
                MembershipTypes = membershipType  
            };
            return View(newModel);
        }

        [HttpPost]
        public ActionResult Create(NewCustomerViewmodel newCustomer)
        {
            _context.Customer.Add(newCustomer.Customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        
        public ActionResult Edit(int id)
        {
            var target = _context.Customer.SingleOrDefault(c => c.Id == id);
            NewCustomerViewmodel newTarget = new NewCustomerViewmodel
            {
                MembershipTypes = _context.membershipTypes,
                Customer = target
            };
            return View("New", newTarget);
        }
    }
}