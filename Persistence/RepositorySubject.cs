using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Persistence.AppRepositories;
namespace Persistence
{

  public class RepositorySubject : IRepositorySubject
  {
    private readonly AppDbContext _appContext = new AppDbContext();
    public Subject Add(Subject subject)
    {
      // subject.TeacherId= subject.Teacher.Id;
      // subject.TutorId= subject.Tutor.Id;
      // subject.Teacher = null;
      // subject.Tutor = null;
      var newSubject = _appContext.Subjects.Add(subject);
      // _appContext.Database.("SET IDENTITY_INSERT dbo.Movies ON;");
      _appContext.SaveChanges();
      return Get(newSubject.Entity.Id);//newSubject.Entity;
    }

    public void Delete(int idSubject)
    {
      var deleteSubject = _appContext.Subjects.FirstOrDefault(p => p.Id == idSubject);
      if (deleteSubject == null)
      {
        return;
      }
      _appContext.Subjects.Remove(deleteSubject);
      _appContext.SaveChanges();
    }

    public IEnumerable<Subject> All()
    {
      return _appContext.Subjects;
    }

    public Subject Get(int idSubject)
    {
      return _appContext.Subjects.FirstOrDefault(p => p.Id == idSubject);
    }

    public Subject Update(Subject subject)
    {
      var updateSubject = _appContext.Subjects.FirstOrDefault(p => p.Id == subject.Id);
      if (updateSubject != null)
      {
        updateSubject.Name = subject.Name;
        updateSubject.Teacher = subject.Teacher;
        updateSubject.Tutor = subject.Tutor;
        _appContext.SaveChanges();
        return updateSubject;
      }
      return updateSubject;
    }
  }
}