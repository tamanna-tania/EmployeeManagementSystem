using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement1.Models
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _db;

        public AccountRepository(AppDbContext db)
        {
            _db = db;
        }
        public Account AddAcount(Account obj)
        {
            _db.Accounts.Add(obj);
            _db.SaveChanges();
            return obj;
        }

        public void DeleteAccount(int id)
        {
            var data = GetAccountById(id);
            if (data != null)
            {
                _db.Remove(data);
            }
            _db.SaveChanges();
        }

       

        public Account GetAccountById(int id)
        {
            Account accounts = _db.Accounts.FirstOrDefault(p => p.Id == id);
            return accounts;
        }

        public IEnumerable<Account> GetAccounts()
        {
            var data = _db.Accounts.Select(p => new Account
            {
                Id = p.Id,
                EmployeeName = p.EmployeeName,
                AccountNumber = p.AccountNumber,
                Salary = p.Salary,
                UrlImage = p.UrlImage,
                TypeId = p.TypeId,
                Type = _db.Types.Where(c => c.Id == p.TypeId).FirstOrDefault()
            }).ToList();
            return data;
        }

        public IEnumerable<Type> GetTypes()
        {
            var data = _db.Types.ToList();
            return data;
        }

        public Account UpdateAccount(Account changeAccount)
        {
            var a = _db.Accounts.Attach(changeAccount);
            a.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return changeAccount;
        }

       

       
    }
}
