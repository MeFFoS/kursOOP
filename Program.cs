using System;
using MySql.Data.MySqlClient;

namespace kursOOP
{
    class Program
    {
        static void AddManufacturer()
        {
            Console.WriteLine("Введите название производителя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите адрес");
            string address = Console.ReadLine();
            Console.WriteLine("Введите телефон");
            string phone = Console.ReadLine();
            var manufacturer = new Manufacturer(name, address, phone);
            manufacturer.Add();
        }

        static void AddMedicine()
        {
            Console.WriteLine("Введите название препарата");
            string name = Console.ReadLine();
            Console.WriteLine("Введите номер производителя");
            int manufacturer = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите цену");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество");
            int count = int.Parse(Console.ReadLine());
            var medicine = new Medicine(name, count, price, manufacturer);
            medicine.Add();
        }

        static void AddSale()
        {
            Console.WriteLine("Введите дату продажи в формате DD/MM/YYYY");
            string dateOfSale = Console.ReadLine();
            Console.WriteLine("Введите артикул препарата");
            int IDMedicine = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество");
            int count = int.Parse(Console.ReadLine());
            var sell = new Sell(dateOfSale, IDMedicine, count);
            sell.Add();
        }
        static void Main(string[] args)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                conn.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return;
            }

            while (true)
            {
                Console.WriteLine("1 - Вывести список препаратов\n2 - Вывести список производителей\n3 - Вывести список продаж\n4 - Добавить препарат\n5 - Добавить производителя\n" +
                                    "6 - Добавить продажу\n7 - Посчитать выручку за день\n0 - Выйти из программы");
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 0:
                        try
                        {
                            conn.Close();
                        }
                        catch (MySqlException e)
                        {
                            Console.WriteLine(e.ToString());
                            return;
                        }
                        Console.ReadKey();
                        return;
                    case 1:
                        Medicine.Print();
                        Console.WriteLine("Нажмите клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Manufacturer.Print();
                        Console.WriteLine("Нажмите клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Sell.Print();
                        Console.WriteLine("Нажмите клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                    case 4:
                        AddMedicine();
                        Console.WriteLine("Нажмите клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                    case 5:
                        AddManufacturer();
                        Console.WriteLine("Нажмите клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                    case 6:
                        AddSale();
                        Console.WriteLine("Нажмите клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                    case 7:
                        Sell.SalesPerDay();
                        Console.WriteLine("Нажмите клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
