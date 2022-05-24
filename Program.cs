using DataModel;
using static StoreLib;

//  Подключение к API
HttpClient httpClient = new HttpClient();
var store = new StoreLib(host: "http://localhost:5166", httpClient: httpClient);

//  Получение каталога из API
var products = await store.GetProduct();
//  Вывод в консоль
ShowCatalog();

//  Добавление нового товара в список
var time = DateTime.Now;
var newProd = new Product(
    name: $"Продукт_{time}",
    price: 44.44);
store.AddProduct(newProd);
Console.Write($"Добавлен: "); ShowProduct(newProd);

//  Обновление каталога из API
products = await store.GetProduct();
//  Вывод в консоль
ShowCatalog();

void ShowCatalog()
{
    //  Выводит каталог в консоль.
    Console.WriteLine($"\n==========  Каталог  ============" );
    
    foreach (Product product in  products)
    {
        Console.WriteLine(product.ToString());
    }
    
    Console.WriteLine($"=================================\n" +
                      $"Товаров в каталоге: {products.Count}\n");
}

void ShowProduct(Product product)
{
    //  Выводит продукт в консоль
    Console.WriteLine(product.ToString());
}