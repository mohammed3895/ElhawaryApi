namespace ElhawaryApi.Models.DTO
{
    public class AccessoryDTO
    {
        public AccessoryDTO()
        {
            this.Id = -1;
            this.Name = string.Empty;
            this.Price = 0;
            this.PurchasePrice = 0;
            this.Qantity = 0;

        }

        public AccessoryDTO(int id, string name, double price, double purchasePrice, int qantity)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.PurchasePrice = purchasePrice;
            this.Qantity = qantity;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public double PurchasePrice { get; set; }
        public int Qantity { get; set; }
    }
}
