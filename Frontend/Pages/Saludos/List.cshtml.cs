using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence;
using Domain.Entities;
namespace Frontend.Pages.Saludos
{
    public class ListModel : PageModel
    {
        private readonly IRepositoryUser _repositoryUser;
        public IEnumerable<User> users {get;set;}
        public ListModel(IRepositoryUser repositoryUser)
        {
            this._repositoryUser = repositoryUser;
        }
        public void OnGet()
        {
            users = _repositoryUser.All();
        }
    }
}
