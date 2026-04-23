namespace EShop.Domain;

public class Product : BaseEntity 
{
    // Sử dụng "private set" để bảo vệ dữ liệu (Encapsulation)
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }

    // Constructor: Cách duy nhất để tạo ra một Sản phẩm hợp lệ
    public Product(string name, decimal price, int stockQuantity) 
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên sản phẩm không được để trống");

        if (price <= 0)
            throw new ArgumentException("Giá phải lớn hơn 0");

        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
    }

    // Phương thức để cập nhật số lượng kho (Logic nghiệp vụ nằm ở đây)
    public void UpdateStock(int quantity) 
    {
        if (StockQuantity + quantity < 0)
            throw new InvalidOperationException("Số lượng hàng trong kho không đủ");

        StockQuantity += quantity;
    }
}