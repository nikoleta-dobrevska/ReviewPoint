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
    public class GenresController : Controller
    {
        private readonly IGenreService genreService;

        public GenresController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(GenreViewModel genreViewModel)
        {
            await this.genreService.Create(genreViewModel);
            return RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var genre = await this.genreService.GetByIdAsync(id);

            return View(genre);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(GenreViewModel genreViewModel)
        {
            await this.genreService.Update(genreViewModel);
            return RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.genreService.Delete(id);
            return RedirectToAction(nameof(this.Index));
        }

        public IActionResult Index()
        {
            var genres = this.genreService.GetAllGenres();
            return View(genres);
        }
    }
}
