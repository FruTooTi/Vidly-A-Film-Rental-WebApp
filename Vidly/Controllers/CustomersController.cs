using System;
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
            //var customers = _context.Customer.Include(c => c.membershipType).ToList();
            return View();
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewCustomerViewmodel newCustomer)
        {
            if (!ModelState.IsValid)
            {
                NewCustomerViewmodel customer = new NewCustomerViewmodel()
                {
                    Customer = newCustomer.Customer,
                    MembershipTypes = _context.membershipTypes.ToList()
                };
                return View("New", customer);
            }
            if(newCustomer.Customer.Id == 0)
                _context.Customer.Add(newCustomer.Customer);
            else
            {
                var customerEdited = _context.Customer.Single(c => c.Id == newCustomer.Customer.Id);
                customerEdited.name = newCustomer.Customer.name;
                customerEdited.surname = newCustomer.Customer.surname;
                customerEdited.BirthdayDate = newCustomer.Customer.BirthdayDate;
                customerEdited.membershipTypeId = newCustomer.Customer.membershipTypeId;
                customerEdited.isSubscribedToNewsLetter = newCustomer.Customer.isSubscribedToNewsLetter;
            }
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