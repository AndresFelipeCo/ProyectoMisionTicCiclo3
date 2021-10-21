using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Persistence.AppRepositories;
namespace Persistence
{

  public class RepositoryUser : IRepositoryUser
  {
    private readonly AppDbContext _appContext = new AppDbContext();
    // TODO: Despublicar para hacer migraciones
    // public RepositoryUser(AppDbContext appContext)
    // {
    //   _appContext = appContext;
    // }
    public User Add(User user)
    {
      var newUser = _appContext.Users.Add(user);
      _appContext.SaveChanges();
      return newUser.Entity;
    }

    public void Delete(int idUser)
    {
      var deleteUser = _appContext.Users.FirstOrDefault(p => p.Id == idUser);
      if (deleteUser == null)
      {
        return;
      }
      _appContext.Users.Remove(deleteUser);
      _appContext.SaveChanges();
    }

    public IEnumerable<User> All()
    {
      return _appContext.Users;
    }

    public User Get(int idUser)
    {
      return _appContext.Users.FirstOrDefault(p => p.Id == idUser);
      // return _appContext.Users.Where(u => u.Id == idUser).Include(u => u.Inscriptions).FirstOrDefault();
    }

    public User Update(User user)
    {
      var updateUser = _appContext.Users.FirstOrDefault(p => p.Id == user.Id);
      if (updateUser != null)
      {
        updateUser.Role = user.Role;
        updateUser.DNI = user.DNI;
        updateUser.Password = user.Password;
        updateUser.FirtsName = user.FirtsName;
        updateUser.LastName = user.LastName;
        updateUser.PhoneNumber = user.PhoneNumber;
        updateUser.Email = user.Email;
        updateUser.Address = user.Address;
        updateUser.Gender = user.Gender;
        updateUser.DegreId = user.DegreId;
        updateUser.Degre = user.Degre;
        updateUser.Inscriptions = user.Inscriptions;
        updateUser.SubjectsTe = user.SubjectsTe;
        updateUser.SubjectsTu = user.SubjectsTu;
        updateUser.Inscriptions = user.Inscriptions;
        updateUser.GuardianId = user.GuardianId;
        updateUser.Guardian = user.Guardian;
        _appContext.SaveChanges();
        return updateUser;
      }
      return updateUser;
    }

    public IEnumerable<User> WithDoubtfully(int idTeacher)
    {
      return _appContext.Users.Where(
        u => u.Inscriptions.Any(
          i => i.Progreses.Any(p => p.State==State.doubtfully)
        )
      );
    }
  }
}