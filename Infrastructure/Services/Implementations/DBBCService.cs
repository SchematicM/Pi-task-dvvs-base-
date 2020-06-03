using Infrastructure.Services.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Implementations
{
    public class DBBCService : IDBBCService
    {
        private CoursesContext _context;

        public DBBCService(CoursesContext context)
        {
            _context = context;
        }

        public IEnumerable<Dbbc> GetDBBC()
        {
            var dbbcs = _context.Dbbc.AsEnumerable();

            return dbbcs;
        }

        public bool AddDBBC(Dbbc dbbc)
        {
            try
            {
                _context.Dbbc.Add(dbbc);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Dbbc GetById(int? id)
        {
            var dbbc = _context.Dbbc.FirstOrDefault(x => x.Id == id);

            return dbbc;
        }

        public bool IncrementById(int id)
        {
            try
            {
                var dbbc = _context.Dbbc.FirstOrDefault(x => x.Id == id);

                if (dbbc.NumberOfSeats == dbbc.NumberSetsUsed)
                {
                    return false;
                }

                dbbc.NumberSetsUsed++;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Save()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
