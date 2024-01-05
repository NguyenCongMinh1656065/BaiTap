namespace BaiTap.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<UserAccount>? UsersAccounts { get; set; }
        public Country? Country { get; set; }
    }
}
