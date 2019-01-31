using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Controllers
{
    //Controller get all borrowed book from each customer and return then back to the library so we need book and customer repository through the constructor
    public class ReturnController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public ReturnController (IBookRepository bookRepository  , ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }

        [Route("Return")]
        public IActionResult List()
        {
            //Load all Borrowed books
            var borrowebooks = _bookRepository.FindWithAuthorAndBorrowner(x => x.BorrownerId != 0);
            if (borrowebooks == null || borrowebooks.Count() == 0)
            {
                return View("Empty");
            }

            return View(borrowebooks);
        }

        public IActionResult ReturnABook(int bookID)
        {
            //Load the Current book
            var book = _bookRepository.GetById(bookID);
            //remove borrower
            book.Borrowner = null;
            book.BorrownerId = 0;
            //update database
            _bookRepository.Update(book);
            //redirect to list
            return RedirectToAction("List");
        }
    }
}