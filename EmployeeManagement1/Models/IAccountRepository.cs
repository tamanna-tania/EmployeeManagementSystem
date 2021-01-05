using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement1.Models
{
 public  interface IAccountRepository
    {

        IEnumerable<Account> GetAccounts();
        Account AddAcount(Account obj);
        Account GetAccountById(int id);
        Account UpdateAccount(Account changeAccount);
        void DeleteAccount(int id);

        IEnumerable<Type> GetTypes();
    }
}
