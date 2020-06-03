using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    public interface IDBBCToUserService
    {
        public IEnumerable<Dbbctouser> GetUsersDbbc();
        public IEnumerable<Dbbctouser> GetUsersDbbcByUserId(string userId);
        public bool AddDBBCToUser(Dbbctouser dbbcToUser);
        public Task<bool> Save();
    }
}
