namespace BaiTap.Models
{
    public class AccountCategory
    {
        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public Account Account { get; set; }
        public Category Category { get; set; }
    }
}
