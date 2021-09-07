using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace kursOOP
{
    class Medicine : IData
    {
        static MySqlConnection conn;
        public int ID { private set; get; }
        public string Name { private set; get; }
        public int Count { private set; get; }
        public int Price { private set; get; }
        public int Manufacturer { private set; get; }

        static Medicine()
        {
            conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return;
            }
        }

        public Medicine(string name, int count, int price, int manufacturer, int id = 0)
        {
            ID = id;
            Name = name;
            Count = count;
            Price = price;
            Manufacturer = manufacturer;
        }
        public void Save()
        {
            string query = String.Format("UPDATE `medicines` SET `name` = '{0}',  `price` = '{1}', `count` = '{2}', `manufacturer` = '{3}' WHERE `ID` = '{4}'", Name, Price, Count, Manufacturer, ID);
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
        }

        public void Add()
        {
            string query = String.Format("INSERT INTO `medicines`(`name`, `price`, `count`, `manufacturer`)  VALUES('{0}', '{1}', '{2}', '{3}')", Name, Price, Count, Manufacturer);
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
        }

        public static void Print()
        {
            string sql = "SELECT * FROM medicines";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            if (!reader.HasRows) Console.WriteLine("Записей не найдено!");
            else
            {
                Console.WriteLine("Арт. Название № Производителя Цена Кол-во");
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[3] + " " + reader[4]);
                }
            }
            reader.Close();
        }
    }
}
