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
    public class EditUserModel : PageModel
    {
        private readonly IRepositoryUser _repositoryUser = new RepositoryUser();
        private readonly IRepositoryInscription _repositoryInscription = new RepositoryInscription();
        private readonly IRepositoryDegree _repositoryDegree = new RepositoryDegree();
        [BindProperty]
        public User user {get;set;}
        public IEnumerable<User> users {get;set;}
        public IEnumerable<Degree> degres {get;set;}
        public IEnumerable<Inscription> Inscriptions {get;set;}
        public String message;
        public IActionResult OnGet(int userId)
        {
            user = _repositoryUser.Get(userId);
            users = _repositoryUser.All();
            degres = _repositoryDegree.All();
            Inscriptions = _repositoryInscription.AllStudent(userId);
            if(user!=null)
            {
                Console.WriteLine(user.Inscriptions);
                return Page();
            }
            else if(user==null && userId==0){
                user = new User();
                return Page();
            }
            return RedirectToPage("/NoFound");
        }
        public IActionResult OnPost()
        {
            degres = _repositoryDegree.All();
            users = _repositoryUser.All();
            if(!ModelState.IsValid){
                return Page();
            }
            if(user.Id>0)
            {
                user = _repositoryUser.Update(user);
                message = "Success";
                Inscriptions = _repositoryInscription.AllStudent(user.Id);
                return Page();
            }
            else{
                user = _repositoryUser.Add(user);
                return Redirect($"/Users/EditUser?userId={user.Id}");
            }
        }
    }
}
