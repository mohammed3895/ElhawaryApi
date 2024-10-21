namespace ElhawaryApi.Models.Domain
{
    public class Accessory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public double PurchasePrice { get; set; }
        public int Qantity { get; set; }
    }
}
