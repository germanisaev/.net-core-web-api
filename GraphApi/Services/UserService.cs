using GraphApi.Helpers;
using GraphApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphApi.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(Login model);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> GetByName(string firstName, string lastname);
        Task<User> Create(User user, string password);
        Task Update(User user, string password = null);
        Task Delete(string username);
    }
    public class UserService : IUserService
    {
        private ApiContext _context;

        public UserService(ApiContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(Login model)
        {
            if (string.IsNullOrEmpty(model.username) || string.IsNullOrEmpty(model.password))
                return null;

            var user = await Task.Run(() => _context.Users.SingleOrDefault(x => x.username == model.username && x.password == model.password));

            if (user == null)
                return null;

            return user;
        }

        public async Task<User> Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new AppException("Password is required");
            }

            if (_context.Users.Any(x => x.username == user.username))
            {
                throw new AppException("Username \"" + user.username + "\" is already taken");
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;

        }

        public async Task Delete(string username)
        {
            //var user = await _context.Users.FindAsync(id);
            var user = await Task.Run(() => _context.Users.SingleOrDefault(x => x.username == username));
            if (user != null)
            {
                await Task.Run(() => _context.Users.Remove(user));
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.Run(() => _context.Users);
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByName(string firstName, string lastName)
        {
            return await Task.Run(() => _context.Users.Where(x => x.firstName == firstName && x.lastName == lastName).FirstOrDefault());
        }

        public async Task Update(User userParam, string password)
        {
            var user = await _context.Users.FindAsync(userParam.id);

            if (user == null)
                throw new AppException("User not found");

            await Task.Run(() => _context.Users.Update(user));
            await _context.SaveChangesAsync();

        }
    }
}
