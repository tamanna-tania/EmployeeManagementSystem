using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement1.Models
{
    public class TypeRepository : ITypeRepository
    {
        private readonly AppDbContext _db;

        public TypeRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Type> GetTypes()
        {
            return _db.Types;
        }
    }
}
