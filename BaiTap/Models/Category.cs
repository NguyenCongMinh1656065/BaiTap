namespace BaiTap.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AccountCategory>? AccountCategories { get; set; }
    }
}
