using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1 - запросы по массиву строк
            string[] array = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            Console.WriteLine("Выборка месяцев с длиной названия, равной 8");
            IEnumerable<string> months1 = array.Where(m => m.Length == 8)
                                               .Select(m => m);
            foreach (string month in months1)
                Console.WriteLine(month);

            Console.WriteLine("Выборка только летних и зимних месяцев");
            IEnumerable<string> months2 = array.Where(m => m.StartsWith("J")
                                                        || m.StartsWith("F")
                                                        || m.StartsWith("Au")
                                                        || m.StartsWith("D"))
                                               .Select(m => m);
            foreach (string month in months2)
                Console.WriteLine(month);

            Console.WriteLine("Выборка месяцев в алфавитном порядке");
            IEnumerable<string> months3 = array.OrderBy(m => m)
                                               .Select(m => m);
            foreach (string month in months3)
                Console.WriteLine(month);

            Console.WriteLine("Количество месяцев, содержащих букву u и длиной имени не менее 4");
            IEnumerable<string> months4 = array.Where(m => m.Contains("u")
                                                        && m.Length >= 4)
                                               .Select(m => m);
            Console.WriteLine(months4.Count());

            // Задание 2, 3 - запросы по пользователскому классу

            List<Product> products = new List<Product>()
            {
                new Product("Гвоздь", 354627378887, 101.1, "Не указан", 502, "Металлопрофиль", "Сделай сам"),
                new Product("Пила циркулярная", 354627662887, 199.69, "Не указан", 1, "Металлопрофиль", "Сделай сам"),
                new Product("Молоко", 345527378887, 5.99, "14 дней", 2, "Савушкин продукт", "Соседи"),
                new Product("Молоко", 345527378887, 4.99, "13 дней", 2, "Ласковое лето", "Соседи"),
                new Product("Творог", 473777354632, 5.89, "10 дней", 2, "Брест-Литовский", "Соседи"),
                new Product("Сметана", 473767464632, 25.89, "10 дней", 10, "Брест-Литовский", "Соседи"),
                new Product("Пицца", 473775656332, 2804, "14 дней", 100, "Papa Johns", "Корона-сити"),
                new Product("Пицца", 466675656332, 1402, "14 дней", 50, "Papa Johns", "Dana Mall"),
            };

            Console.WriteLine("\nВыборка товаров для заданного наименования - Молоко");
            IEnumerable<Product> products1 = products.Where(p => p.ProdName == "Молоко");
            foreach (Product prod in products1)
                Console.WriteLine(prod.ToString());

            Console.WriteLine("\nВыборка товаров, цена которых меньше 10, но больше 5");
            IEnumerable<Product> products2 = products.Where(p => p.ProdPrice <= 10 && p.ProdPrice >= 5);
            foreach (Product prod in products2)
                Console.WriteLine(prod.ToString());

            Console.WriteLine("\nКоличество наименований, цена которых больше 100");
            IEnumerable<Product> products3 = products.Where(p => p.ProdPrice >= 100);
            Console.WriteLine(products3.Count());

            Console.WriteLine("\nМаксимальный по цене товар");
            Console.WriteLine(products.Max(p => p.ProdPrice));

            Console.WriteLine("\nУпорядоченный список товаров по производителю, а затем по количеству");
            IEnumerable<Product> products4 = products.OrderBy(p => p.ProdProducer)
                                                     .ThenByDescending(p => p.ProdAmount);
            foreach (Product prod in products4)
                Console.WriteLine(prod.ToString());

            // Задание 4 - запрос из 5 операторов

            Console.WriteLine("\nЗапрос с использованием 5 операторов");
            IEnumerable<Product> products5 = products.Skip(3)
                                                     .OrderBy(p => p.ProdName)
                                                     .Where(p => p.ProdLife.Contains("дней"))
                                                     .Select(p => p);
            foreach (Product prod in products5)
                Console.WriteLine(prod.ToString());

            // Зададние 5 - использование оператора Join

            Console.WriteLine("\nЗапрос с использованием оператора Join");
            Place place1 = new Place("Соседи", "Минск");
            Place place2 = new Place("Корона-сити", "Витебск");

            List<Place> places = new List<Place>();
            places.Add(place1);
            places.Add(place2);

            var result = products.Join(places,
                         pr => pr.StoreName,
                         pl => pl.Store,
                         (pr, pl) => new
                         {
                             ID = pr.ProdID,
                             Name = pr.ProdName,
                             UPC = pr.ProdUPC,
                             Price = pr.ProdPrice,
                             Life = pr.ProdLife,
                             Amount = pr.ProdAmount,
                             Producer = pr.ProdProducer,
                             Store = pr.StoreName,
                             City = pl.City
                         });
            foreach (var prod in result)
                Console.WriteLine($"ID - {prod.ID}, наименование - {prod.Name}, UPC - {prod.UPC}, цена - {prod.Price}, срок годности - {prod.Life}" +
                    $" количество - {prod.Amount}, производитель - {prod.Producer}, магазин - {prod.Store}, город - {prod.City}\n");

            Console.ReadKey();
        
    }
    }
}
