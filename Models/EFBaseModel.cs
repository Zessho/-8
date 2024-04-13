namespace FinanceAPI.Models
{
    public class EFBaseModel
    {
        public EFBaseModel() { }
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
