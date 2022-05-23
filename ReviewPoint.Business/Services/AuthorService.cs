using AutoMapper;
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
    public class AuthorService : BaseDataService<Author, AuthorViewModel, IAuthorRepository>, IAuthorService
    {
        public AuthorService(IAuthorRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public IEnumerable<AuthorViewModel> GetAllAuthors()
        {
            var authors = this.repository.GetAll().Select(a => new AuthorViewModel
            {
                Id = a.Id,
                Name=a.Name
            }) ;
            return authors;
        }

        public IEnumerable<Author> GetAuthors()
        {

            return this.repository.GetAll();

        }
    }
}
