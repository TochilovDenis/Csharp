﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_03
{
    internal class Program
    {

        SqlConnection conn = null;

        public Program()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"
            Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=Название БД;
            Integrated Security=SSPI;";


            //Data Source = (localdb)\MSSQLLocalDB;
            //Initial Catalog = Library; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False
        }

        static void Main(string[] args)
        {

            Program pr = new Program();
            pr.InsertQuery();

        }

        public void InsertQuery()
        {
            try
            {
                //открыть соединение
                conn.Open();
                //подготовить запрос insert
                //в переменной типа string
                string insertString = @"insert into
                        [dbo].[Authors] (FirstName, LastName)
                         values ('Roger', 'Zelazny')";
                //создать объект command,
                //инициализировав оба свойства
                SqlCommand cmd =
                new SqlCommand(insertString, conn);

                //выполнить запрос, занесенный
                //в объект command
                cmd.ExecuteNonQuery();
            }
            finally
            {


                // закрыть соединение
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
}
    public void ReadData()
        {
            SqlDataReader rdr = null;
            try
            { //открыть соединение
                conn.Open();
                //создать новый объект command с запросом select
                SqlCommand cmd = new SqlCommand("select * from Authors", conn);
                //выполнить запрос select, сохранив
                //возвращенный результат
                rdr = cmd.ExecuteReader();
                //извлечь полученные строки
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[1] + " " + rdr[2]);
                }
            }
            finally
            {
                //закрыть reader
                if (rdr != null)
                {
                    rdr.Close();
                }
                //закрыть соединение
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public void ReadData2()
        {
            SqlDataReader rdr = null;
            try
            {
                //открыть соединение
                conn.Open();

                //создать новый объект command с запросом select
                SqlCommand cmd = new SqlCommand("select * from Authors; select * from Authors", conn);

                //выполнить запрос select, сохранив возвращенный результат
                rdr = cmd.ExecuteReader();
                int line = 0; //счетчик строк//извлечь полученные строки

                do
                {
                    while (rdr.Read())
                    {
                        //формируем шапку таблицы перед выводом первой строки
                        if (line == 0)
                        {
                            //цикл по числу прочитанных полей
                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                //вывести в консольное окно имена полей
                                Console.Write(rdr.GetName(i).ToString() + " ");
                            }
                            Console.WriteLine();
                        }
                        line++;
                        Console.WriteLine(rdr[1] + " " + rdr[2]);
                    }
                    Console.WriteLine("Обработано записей: " + line.ToString());

                } while (rdr.NextResult());
            }
            finally
            {
                //закрыть reader
                if (rdr != null)
                {
                    rdr.Close();
                }
                //закрыть соединение
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

    }

}
