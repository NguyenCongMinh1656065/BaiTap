using BaiTap.Data;
using BaiTap.Models;

namespace BaiTap
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.UserAccounts.Any())
            {
                var userAccounts = new List<UserAccount>
                {
                    new UserAccount
                    {
                        Account = new Account
                        {
                            Number = "0012013642",
                            Balance = "4,000,000,000",
                            AccountCategories = new List<AccountCategory>
                            {
                                new AccountCategory {Category = new Category {Name = "Member"}}
                            }
                        },
                        User = new User
                        {
                            Name = "Nguyen Cong Minh",
                            Country = new Country {Name = "HaNoi"}
                        }
                    },
                    new UserAccount
                    {
                        Account = new Account
                        {
                            Number = "0012013643", // Unique account number
                            Balance = "10,000,000,000",
                            AccountCategories = new List<AccountCategory>
                            {
                                new AccountCategory {Category = new Category {Name = "Vip"}}
                            }
                        },
                        User = new User
                        {
                            Name = "Van Thuy Chi",
                            Country = new Country {Name = "SaiGon"}
                        }
                    },
                    new UserAccount
                    {
                        Account = new Account
                        {
                            Number = "0012013644", // Unique account number
                            Balance = "20,000,000,000",
                            AccountCategories = new List<AccountCategory>
                            {
                                new AccountCategory {Category = new Category {Name = "VVip"}}
                            }
                        },
                        User = new User
                        {
                            Name = "Le Gia Huy",
                            Country = new Country {Name = "DaNang"}
                        }
                    }
                };

                foreach (var userAccount in userAccounts)
                {
                    if (!dataContext.UserAccounts.Any(u => u.Account.Number == userAccount.Account.Number))
                    {
                        dataContext.UserAccounts.Add(userAccount);
                    }
                }

                dataContext.SaveChanges();
            }
        }
    }
}
