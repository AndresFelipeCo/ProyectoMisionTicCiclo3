using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence;
using Domain.Entities;

namespace Frontend.Pages.Users
{
    public class ListModel : PageModel
    {
        private readonly IRepositoryUser _repositoryUser = new RepositoryUser();
        public IEnumerable<User> users {get;set;}
        public User user;
        public IActionResult OnGet(int userId)
        {
            user = _repositoryUser.Get(userId);
            if(user!=null)
            {
                Console.WriteLine(userId);
                return Page();
            }
            else if(user==null && userId > 0)
            {
                return RedirectToPage("/NoFound");
            }
            else{
                users = _repositoryUser.All();
                // El siguiente filtro es funcional y trae los estudiantes con dudas
                // users = _repositoryUser.WithDoubtfully(1);
                return Page();
            }
        }
    }
}
