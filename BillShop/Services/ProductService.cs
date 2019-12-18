using BillShop.DAO;

namespace BillShop.Services
{
    public class ProductService
    {
        public IProduct Product { get; }
        public string FilePath { get; }

        public ProductService(string filePath)
        {
            this.FilePath = filePath;
            this.Product = new CsvProductRepository();
        }
        
        
        public bool ProductExist(int barcode)
        {
            return Product.GetByBarcode(barcode, FilePath) != null;
        }

        public Product GetProduct(int barcode)
        {
            return Product.GetByBarcode(barcode, FilePath);
        }
    }
}