public class Product
{
    private string _nameProduct;
    private int _productId;
    private double _price;
    private int _quantity;
    public Product(string nameProduct, int productId, double price, int quantity)
    {
        _nameProduct = nameProduct;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetProductName()
    {
        return _nameProduct;
    }

    public int GetProductId()
    {
        return _productId;
    }
}