using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReviewPoint.Business.Services.Interfaces;
using ReviewPoint.Business.ViewModels;
using ReviewPoint.Data.Repositories;
using ReviewPoint.Entities;
using ReviewPoint.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewPoint.Business.Services
{
   public class GenreService : BaseDataService<Genre, GenreViewModel, IGenreRepository>, IGenreService
    {
        public GenreService(IGenreRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public IEnumerable<GenreViewModel> GetAllGenres()
        {
            var genres = this.repository.GetAll().Select(g => new GenreViewModel
            {
                Id = g.Id,
                Name = g.Name
            });
            return genres;
        }

        public IEnumerable<Genre> GetGenres()
        {
            
           return this.repository.GetAll();
            
        }
    }
}
