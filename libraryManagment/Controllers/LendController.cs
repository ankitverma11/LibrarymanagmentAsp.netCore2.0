using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Data.Interfaces;
using LibraryManagment.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Controllers
{
    public class LendController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public LendController(IBookRepository bookRepository , ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }
        [Route("Lend")]
        public IActionResult List()
        {
            var availablebook = _bookRepository.FindWithAuthor(x => x.BorrownerId == 0);
           if (availablebook.Count() == 0)
            {
                return View("Empty");
            }
           else
            {
                return View(availablebook);
            }
        }

        public IActionResult LendBook(int bookID)
        {
            //Load CurrentBook and All Customer
            //Send data to the lend view
            var LendVm = new LendViewModel()
            {
                Book = _bookRepository.GetById(bookID),
                Customers = _customerRepository.GetAll()
               };

            return View(LendVm);
        }

        [HttpPost]
        public IActionResult LendBook(LendViewModel lendViewModel)
        {
            //update the database
            var book = _bookRepository.GetById(lendViewModel.Book.BookId);
            var customer = _customerRepository.GetById(lendViewModel.Book.BorrownerId);
            book.Borrowner = customer;
            _bookRepository.Update(book);

            //redirect to ist view
            return RedirectToAction("List");
        }



    }
}