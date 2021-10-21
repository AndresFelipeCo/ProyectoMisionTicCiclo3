using System;
using Persistence;
using Domain.Entities;
namespace Consola
{
  class Program
  {
    private static IRepositoryDegree _repositoryDegree = new RepositoryDegree();
    private static IRepositoryUser _repositoryUser = new RepositoryUser();
    private static IRepositorySubject _repositorySubject = new RepositorySubject();
    private static IRepositoryInscription _repositoryInscription = new RepositoryInscription();
    static void Main(string[] args)
    {
      // Console.WriteLine(_repositoryDegree.Get(1).Name);
      User user = Add();
      // Console.WriteLine(user.Id +"\n"+user.FirtsName);
      // var subject = Get(1);
      // Console.WriteLine(subject);

    }
    private static User Add()
    {
      var degree = _repositoryDegree.Add(
        new Degree
        {
          Name = "Semestre 2"
        }
      );

      var teacher = _repositoryUser.Add(
        new User
        {
          Role = Role.teacher,
          DNI = "86754435",
          Password = "12345",
          FirtsName = "Andres",
          LastName = "Burbano",
          PhoneNumber = "3143062988",
          Email = "andrefelipe@udenar.edu.co",
          Gender = Gender.male,
          Degre = null,
          Guardian = null,
        }
      );
      var tutor = _repositoryUser.Add(
        new User
        {
          Role = Role.tutor,
          DNI = "1069935127",
          Password = "12345",
          FirtsName = "Ever",
          LastName = "Gómez",
          PhoneNumber = "3004384631",
          Email = "ag2725@gmail.com",
          Gender = Gender.male,
          Degre = null,
          Guardian = teacher,
        }
      );
      var subject = _repositorySubject.Add(
        new Subject
        {
          Name = "Maths",
          TeacherId = teacher.Id,
          TutorId = tutor.Id,
        }
      );
      var guardian = _repositoryUser.Add(
        new User
        {
          Role = Role.guardian,
          DNI = "42527698",
          Password = "12345",
          FirtsName = "Luis",
          LastName = "Hincapie",
          PhoneNumber = "3143062988",
          Email = "daguerotipo@gmail.com",
          Gender = Gender.male,
          Degre = null,
          Guardian = null,
        }
      );

      
      var student = _repositoryUser.Add(
        new User
        {
          Role = Role.student,
          DNI = "1039589329",
          Password = "12345",
          FirtsName = "Jhonatan",
          LastName = "Gómez",
          PhoneNumber = "3004384631",
          Email = "joeduque89@icloud.com",
          Gender = Gender.male,
          Degre = degree,
          Guardian = guardian,
        }
      );
      // var inscription = _repositoryInscription.Add(
      //   new Inscription
      //   {
      //     Student = student,
      //     Subject = subject,
      //   }
      // );
      return teacher;
    }
    private static Subject Get(int idUser)
    {
      return _repositorySubject.Get(idUser);
    }
  }
}
