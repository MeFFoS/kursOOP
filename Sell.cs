using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace kursOOP
{
    class Sell : IData
    {
        static MySqlConnection conn;
        public string DateSale { private set; get; }
        public int IDMedicine { private set; get; }
        public int Count { private set; get; }

        static Sell()
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

        public Sell(string dateSale, int idMedicine, int count)
        {
            DateSale = dateSale;
            IDMedicine = idMedicine;
            Count = count;
        }

        public void Save()
        {
            string query = String.Format("UPDATE `selling` SET `Count` = '{0}' WHERE `IDMedicine` = '{1}' AND `DateSale` = '{2}'", Count, IDMedicine, DateSale);
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
        }

        public void AddSale(int count)
        {
            Count += count;
        }

        public void Add()
        {
            string query = String.Format("INSERT INTO `selling`(`DateSale`, `IDMedicine`, `Count`) VALUES('{0}', '{1}', '{2}')", DateSale, IDMedicine, Count);
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
        }

        public static void Print()
        {
            string sql = "SELECT * FROM selling";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            if (!reader.HasRows) Console.WriteLine("Записей не найдено!");
            else
            {
                Console.WriteLine("Дата продажи Арт. лекарства Кол-во");
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
                }
            }
            reader.Close();
        }

        public static void SalesPerDay()
        {
            Console.WriteLine("Введите день продажи в формате DD/MM/YYYY");
            string dayOfSale = Console.ReadLine();
            string sql = String.Format("SELECT * FROM `selling` WHERE `DateSale` = '{0}'", dayOfSale);
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            if (!reader.HasRows) Console.WriteLine("Записей не найдено!");
            else
            {
                int profit = 0;
                var list = new List<Sell>();

                while (reader.Read())
                {
                    list.Add(new Sell(reader[0].ToString(), (int)reader[1], (int)reader[2]));
                }
                reader.Close();

                foreach (var e in list)
                {
                    sql = String.Format("SELECT price FROM medicines WHERE ID = {0}", e.IDMedicine);
                    command = new MySqlCommand(sql, conn);
                    profit += int.Parse(command.ExecuteScalar().ToString()) * e.Count;
                }

                Console.WriteLine("Выручка за " + dayOfSale + " составила " + profit);
            }
        }
    }
}
