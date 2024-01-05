using BaiTap.Dto;
using BaiTap.Models;

namespace BaiTap.interfaces
{
    public interface IAccountRepisitory
    {
        ICollection<Account> GetAccounts();
        Account GetAccount(int id);
        Account GetAccount(string Number);
        Account GetAccountTrimToUpper(AccountDto accountCreate);
        bool AccountExists(int accId);
        bool CreateAccount(int userId, int categoryId, Account account);
        bool UpdateAccount(int userId, int categoryId, Account account);
        bool DeleteAccount(Account account );
        bool Save();
    }
}
