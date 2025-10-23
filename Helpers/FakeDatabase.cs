namespace ExampleApplication.Helpers
{
    static public class FakeDatabase
    {
        static public List<Product> _products = new List<Product>() {
            new Product{
                Id = 1,
                Name = "Пазл",
                Code = "001",
                Price = 1500,
                Quantity = 100
            },
            new Product{
                Id = 2,
                Name = "Зеленка",
                Code = "002",
                Price = 900,
                Quantity = 5
            },
            new Product{
                Id = 3,
                Name = "Елка",
                Code = "003",
                Price = 15000,
                Quantity = 5
            },
            new Product{
                Id = 4,
                Name = "Процессор",
                Code = "004",
                Price = 23000,
                Quantity = 100
            }
        };
    }
}
