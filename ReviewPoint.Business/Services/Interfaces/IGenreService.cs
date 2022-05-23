using ReviewPoint.Business.ViewModels;
using ReviewPoint.Entities;
using ReviewPoint.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewPoint.Business.Services.Interfaces
{
    public interface IGenreService : IBaseDataService<Genre, GenreViewModel>
    {
        IEnumerable<Genre> GetGenres();
        IEnumerable<GenreViewModel> GetAllGenres();

    }
}
