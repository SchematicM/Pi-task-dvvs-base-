using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    public interface IDBBCService
    {
        public IEnumerable<Dbbc> GetDBBC();
        public bool AddDBBC(Dbbc dbbc);
        public Dbbc GetById(int? id);
        public bool IncrementById(int id);
        public Task<bool> Save();
    }
}
