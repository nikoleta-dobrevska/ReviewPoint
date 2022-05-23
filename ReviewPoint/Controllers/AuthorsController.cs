using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewPoint.Business.Services.Interfaces;
using ReviewPoint.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewPoint.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService authorService;

        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(AuthorViewModel authorViewModel)
        {
            await this.authorService.Create(authorViewModel);
            return RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.authorService.Delete(id);
            return RedirectToAction(nameof(this.Index));
        }
        public IActionResult Index()
        {
            var authors = this.authorService.GetAllAuthors();
            return View(authors);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var author = await this.authorService.GetByIdAsync(id);

            return View(author);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(AuthorViewModel authorViewModel)
        {
            await this.authorService.Update(authorViewModel);
            return RedirectToAction(nameof(this.Index));
        }
    }
}
