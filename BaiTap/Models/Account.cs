namespace BaiTap.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public string? Balance { get; set; }
        public ICollection<UserAccount>? UsersAccounts { get; set; }
        public ICollection<AccountCategory>? AccountCategories { get; set; }

    }
}
