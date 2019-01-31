using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Models;
using LibraryManagment.Data.Interfaces;
using LibraryManagment.ViewModel;

namespace LibraryManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private ICustomerRepository _customerRepository;
        private readonly IAuthorRepository _authorRepository;

        public HomeController(IBookRepository bookRepository , ICustomerRepository customerRepository , IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
            _authorRepository = authorRepository;
        }
        public IActionResult Index()
        {
            var HomeVm = new HomeViewModel
            {
                AuthorCount = _authorRepository.Count(x => true),
                CustomerCount = _customerRepository.Count(x => true),
                BookCount = _bookRepository.Count(x => true),
                LendBookCount = _bookRepository.Count(x => x.Borrowner != null)
            };
            return View(HomeVm);
        }

    
    }
}
