namespace ExampleApplication.Helpers
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
        public int Price { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public int Income => Price * Quantity;
    }
}
