namespace EShop.Domain;

public class Product : BaseEntity
{
    // 1. Các thuộc tính với "private set" để bảo vệ dữ liệu (Encapsulation)
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; } // Đổi từ StockQuantity thành Stock cho khớp với DbContext

    // 2. Constructor không tham số dành riêng cho Entity Framework Core
    private Product() { }

    // 3. Constructor chính để khởi tạo Object hợp lệ
    public Product(string name, decimal price, int stock)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên sản phẩm không được để trống");

        if (price <= 0)
            throw new ArgumentException("Giá phải lớn hơn 0");

        if (stock < 0)
            throw new ArgumentException("Số lượng tồn kho không được âm");

        Name = name;
        Price = price;
        Stock = stock;
    }

    // 4. Các phương thức để thay đổi trạng thái (Ghi điểm với HR)
    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0) throw new ArgumentException("Giá mới phải lớn hơn 0");
        Price = newPrice;
    }
}
