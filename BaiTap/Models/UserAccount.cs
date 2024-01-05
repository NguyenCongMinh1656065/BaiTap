namespace BaiTap.Models
{
    public class UserAccount
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public Account? Account { get; set; }
        public User? User { get; set; }

    }
}
