using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace kursOOP
{
    class Manufacturer : IData
    {
        static MySqlConnection conn;
        public int ID { private set; get; }
        public string Name { private set; get; }
        public string Address { private set; get; }
        public string Phone { private set; get; }

        static Manufacturer()
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

        public Manufacturer(string name, string address, string phone, int id = 0)
        {
            ID = id;
            Name = name;
            Address = address;
            Phone = phone;
        }

        public void Save()
        {
            string query = String.Format("UPDATE `manufacturers` SET `name` = '{0}',  `address` = '{1}', `phone` = '{2}' WHERE `ID` = '{3}'", Name, Address, Phone, ID);
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
        }

        public void Add()
        {
            string query = String.Format("INSERT INTO `manufacturers`(`name`,`address`,`phone`) VALUES('{0}', '{1}', '{2}')", Name, Address, Phone);
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
        }

        public static void Print()
        {
            string sql = "SELECT * FROM manufacturers";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            if (!reader.HasRows) Console.WriteLine("Записей не найдено!");
            else
            {
                Console.WriteLine("№ Производителя Название Адрес Телефон");
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[3]);
                }
            }
            reader.Close();
        }
    }
}
