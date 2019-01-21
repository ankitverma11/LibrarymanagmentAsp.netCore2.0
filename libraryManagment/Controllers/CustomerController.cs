using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Data.Interfaces;
using LibraryManagment.Data.Model;
using LibraryManagment.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IBookRepository _BookRepository;
        // create a Construnctor and inject there repository by service (DI)
        public CustomerController(ICustomerRepository CustomerRepository , IBookRepository BookRepository)
        {
            _CustomerRepository = CustomerRepository;
            _BookRepository = BookRepository;
        }
        [Route("Customer")]
        public IActionResult List()
        {
            var CustomerVM = new List<CustomerViewModel>();
            var customers = _CustomerRepository.GetAll();
            if (customers.Count() == 0)
            {
                return View("Empty");
            }
            foreach (var customer in customers)
            {
                CustomerVM.Add(new CustomerViewModel
                {
                    Customer = customer,
                    BookCount = _BookRepository.Count(x => x.BorrownerId == customer.CustomerId)
                });
            }
            return View(CustomerVM);
        }

        public IActionResult Delete (int id)
        {
            var customer = _CustomerRepository.GetById(id);
            _CustomerRepository.Delete(customer);
            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }

        //In this view we have to create a Post Request to Create A customer
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _CustomerRepository.Create(customer);
            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var customer = _CustomerRepository.GetById(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            _CustomerRepository.Update(customer);
            return RedirectToAction("List");
        }

    }
}
