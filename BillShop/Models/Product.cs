namespace BillShop
{
    public class Product
    {
        public Product(int barCode, string name, double price , int amount)
        {
            BarCode = barCode;
            Name = name;
            Price = price;
            Amount = amount;
        }

        public Product(int barCode, string name, double price)
        {
            BarCode = barCode;
            Name = name;
            Price = price;
            Amount = 1;
        }

        public int BarCode { get; }
        public string Name { get; }
        public double Price { get; set; }
        public int Amount { get; set; }


        private bool Equals(Product other)
        {
            return BarCode == other.BarCode && Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (BarCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }
    }
}