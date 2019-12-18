
namespace BillShop
{
    public class Discount
    {
        public Discount(int barcode, int amount, double discountValue)
        {
            Barcode = barcode;
            Amount = amount;
            DiscountValue = discountValue;
        }

        public int Barcode { get; }
        public int Amount { get; }
        public double DiscountValue { get;}
    }
}