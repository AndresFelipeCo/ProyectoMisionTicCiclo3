using System.Collections.Generic;
using Domain.Entities;

namespace Persistence
{
  public interface IRepositoryUser
  {
    IEnumerable<User> All();
    IEnumerable<User> WithDoubtfully(int idTeacher);
    User Add(User user);
    User Update(User user);
    void Delete(int idUser);
    User Get(int idUser);
  }
}