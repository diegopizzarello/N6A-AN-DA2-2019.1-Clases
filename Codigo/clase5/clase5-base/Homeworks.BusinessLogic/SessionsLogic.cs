using System;

using Homeworks.Domain;
using Homeworks.DataAccess;

namespace Homeworks.BusinessLogic
{
  public class SessionsLogic : ISessionsLogic
  {
    private IRepository<Session> sessionRepository;
    private IRepository<User> userRepository;

    public SessionsLogic(IRepository<Session> sessionRepository, IRepository<User> userRepository) {
        this.sessionRepository = sessionRepository;
        this.userRepository = userRepository;
    }

    public Guid Login(string username, string password)
    {
        Guid sessionToken = new Guid();
        User user = userRepository.GetFirst(u => u.UserName == username && u.Password == password);
        if (user == null) {
            throw new ArgumentException("Username/Password not valid");
        }
        Session session = new Session() { token = sessionToken, user = user };
        return sessionToken;
    }

    public void Dispose()
    {
        sessionRepository.Dispose();
        userRepository.Dispose();
    }

  }
}