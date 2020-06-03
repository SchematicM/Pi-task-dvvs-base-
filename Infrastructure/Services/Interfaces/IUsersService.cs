using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    public interface IUsersService
    {
        public IEnumerable<AspNetUsers> GetUsers();
        public IEnumerable<AspNetUsers> GetUserByCredit(string credit);
        public bool AddUser(AspNetUsers user);
        public AspNetUsers GetUserById(string id);
        public Task<bool> Save();
    }
}
