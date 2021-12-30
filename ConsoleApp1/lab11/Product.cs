using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class Product
    {
        // поля класса
        private readonly int prodID;
        private string prodName;
        private long prodUPC;
        private double prodPrice;
        private string prodLife;
        private int prodAmount;
        private string prodProducer;
        private string storeName;    // статическое поле
        private const double dollarExchangeRate = 2.50;   // поле-константа
        static int objAmount;

        // свойства
        public int ProdID => prodID;    // == { get { return prodID; } }

        public string ProdName
        {
            get => prodName;
            set => prodName = value;
        }
        public string StoreName
        {
            get => storeName;
            set => storeName = value;
        }
        public long ProdUPC
        {
            get => prodUPC;
            private set => prodUPC = value; // ограничение аксессора не дает изменить поле вне класса
        }

        public double ProdPrice
        {
            get => prodPrice;
            set
            {
                do
                {
                    if (value < 0)
                        Console.WriteLine("Цена продукта не может быть меньше нуля. Попробуйте еще раз.");
                    else
                        prodPrice = value;
                } while (value < 0);
            }
        }

        public string ProdLife
        {
            get => prodLife;
            set => prodLife = value;
        }

        public int ProdAmount
        {
            get => prodAmount;
            set
            {
                do
                {
                    if (value < 0)
                        Console.WriteLine("Количество продукта не может быть отрицательным числом. Попробуйте еще раз.");
                    else
                        prodAmount = value;
                } while (value < 0);
            }
        }
        public string ProdProducer
        {
            get => prodProducer;
            set => prodProducer = value;
        }

        // методы
        public void SomeMethodDoing()
        {
            Console.WriteLine("Sample Text");
        }
        public void Info()
        {
            Console.WriteLine($"Объектов создано : {objAmount}");
            Console.WriteLine($"Магазин - {storeName}");
        }
        public double GetCostInDollars(out double cost)
        {
            cost = prodPrice / dollarExchangeRate;
            return cost;
        }
        //public override int GetHashCode()   // переопределенный метод GetHashCode для класса Product
        //{
        //    return HashCode.Combine(prodName, prodUPC, prodPrice, prodLife, prodAmount);
        //}
        public static Product DefConstructor()  //метод, вызывающий закрытый конструктор
        {
            return new Product();
        }
        public double GetSumPrice()
        {
            double sum = prodAmount * prodPrice;
            return sum;
        }
        public double ChangeDisc(ref double disc)
        {
            disc += 1.5;
            return disc;
        }
        public override bool Equals(object obj) //переопределенный метод сравнения двух объектов
        {
            if (obj is Product objectType)
            {
                if (this.prodID == objectType.prodID && this.prodName == objectType.prodName && this.prodUPC == objectType.prodUPC
                        && this.prodPrice == objectType.prodPrice && this.prodLife == objectType.prodLife
                            && this.prodAmount == objectType.prodAmount)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return $"Наименование - {prodName}, ID - {prodID}, UPC- {prodUPC}, цена - {prodPrice} рубля(ей), " +
                $"срок хранения - {prodLife}, количество - {prodAmount}, производитель - {prodProducer}, магазин - {storeName}.";
        }

        // конструкторы
        /*static Product()    // статический конструктор
        {
            Console.WriteLine("Некий товар был создан");
        }*/
        private Product()    // закрытый конструктор без параметров
        {
            prodName = "Яблоки";
            prodUPC = 374524153788;
            prodPrice = 0.26;
            prodLife = "5 дней";
            prodAmount = 5;
            prodID = GetHashCode();
            objAmount++;
        }
        public Product(string naMe, long u, int amnt)    // конструктор с параметрами
        {
            prodName = naMe;
            prodUPC = u;
            prodAmount = amnt;
           // prodID = HashCode.Combine(naMe, u, amnt);  // вычисление хeш на основе инициализаторов
            objAmount++;
        }
        public Product(string n, long u, string l = "14 дней", double price = 1.1)  // конструктор с параметрами по умолчанию
        {
            prodName = n;
            prodUPC = u;
            prodLife = l;
            prodPrice = price;
            prodID = GetHashCode();
            objAmount++;
        }
        public Product(string name, long upc, double price, string life, int amount, string producer, string store)
        {
            prodName = name;
            prodUPC = upc;
            prodPrice = price;
            prodLife = life;
            prodAmount = amount;
            prodProducer = producer;
            storeName = store;
            prodID = GetHashCode();
            objAmount++;
        }
    }
}
