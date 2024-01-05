using BaiTap.Data;
using BaiTap.Dto;
using BaiTap.interfaces;
using BaiTap.Models;

namespace BaiTap.Repository
{
    public class AccountRepository : IAccountRepisitory
    {
        private DataContext _context;

        public AccountRepository(DataContext context) 
        {
            _context = context;
        }

        public Account GetAccount(int id)
        {
            return _context.Account.Where(a => a.Id == id).FirstOrDefault(); 
        }

        public Account GetAccount(string Number)
        {
            return _context.Account.Where(a => a.Number == Number).FirstOrDefault();
        }

        public ICollection<Account> GetAccounts()
        {
            return _context.Account.OrderBy(a => a.Id).ToList();
        }

        public bool AccountExists(int accId)
        {
            return _context.Account.Any(a => a.Id == accId);
        }

        public bool CreateAccount(int userId, int categoryId, Account account)
        {
            var useraccountEntity = _context.Users.Where(a => a.Id == userId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var useraccount = new UserAccount()
            {
                User = useraccountEntity,
                Account = account,
            };

            _context.Add(useraccount);

            var accountCategory = new AccountCategory()
            {
                Category = category,
                Account = account,
            };

            _context.Add(accountCategory);

            _context.Add(account);

            return Save();
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public Account GetAccountTrimToUpper(AccountDto accountCreate)
        {
            return GetAccounts().Where(c => c.Number.Trim().ToUpper() == accountCreate.Number.TrimEnd().ToUpper())
               .FirstOrDefault();
        }

        public bool UpdateAccount(int userId, int categoryId, Account account)
        {
            _context.Update(account);
            return Save();
        }

        public bool DeleteAccount(Account account)
        {
            _context.Remove(account);
            return Save();
        }
    }
}
