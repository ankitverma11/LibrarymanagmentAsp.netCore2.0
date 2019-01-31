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
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookController(IBookRepository bookrepository , IAuthorRepository authorRepository)
        {
            _bookRepository = bookrepository;
            _authorRepository = authorRepository;
        }
        [Route("Book")]
        public IActionResult List(int? authorId , int? borrowerId)
        {
           if (authorId == null && borrowerId == null)
            {
                //Show All books
                var books = _bookRepository.GetAllWithAuthor();
                return Checkbook(books);
             }
            else if (authorId != null)
            {
                //Filter by AuthorID and Check Author book
                var author = _authorRepository.GetWithBooks((int)authorId);
                if (author.Books.Count() == 0)
                {
                    return View("AuthorEmpty", author);
                }
                else
                {
                    return View(author.Books);
                }
            }
            else if (borrowerId != null)
            {
                //Filter by borrowerId and Check borrower book
                var books = _bookRepository.FindWithAuthorAndBorrowner(x => x.BorrownerId == borrowerId);
                return Checkbook(books);
            }
            else
            {
                //throw exception
                throw new Exception();
            }

        }

        public IActionResult Checkbook(IEnumerable<Book> books)
        {
            if (books.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(books);
            }
        }

        public IActionResult Create()
        {
            var bookVm = new BookViewModel()
            {
                Authors = _authorRepository.GetAll()
            };
           return View(bookVm);
        }

        [HttpPost]
        public IActionResult Create(BookViewModel bookViewModel)
        {
            _bookRepository.Create(bookViewModel.Book);
            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var bookVm = new BookViewModel()
            {
                Book = _bookRepository.GetById(id),
                Authors = _authorRepository.GetAll()
            };
            return View(bookVm);
        }

        [HttpPost]
        public IActionResult Update(BookViewModel bookViewModel)
        {
            _bookRepository.Update(bookViewModel.Book);
            return RedirectToAction("List");
        }

        public IActionResult Delete (int id)
        {
            var book = _bookRepository.GetById(id);
            _bookRepository.Delete(book);
            return RedirectToAction("List");
        }
    }
}