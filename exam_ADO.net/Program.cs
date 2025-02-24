using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_ADO.net
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new MusicStoreDB();

            // Добавление новой пластинки
            var record = new VinylRecord
            {
                Title = "Новая Пластинка",
                Artist = "Группа",
                Publisher = "Издательство",
                TrackCount = 12,
                GenreId = 1,
                ReleaseYear = 2025,
                CostPrice = 500,
                SellingPrice = 750,
                Quantity = 10
            };
            db.AddRecord(record);

            // Поиск пластинок
            var foundRecords = db.SearchRecords(title: "Новая");

            // Продажа
            var sale = new Sale
            {
                RecordID = 1,
                CustomerID = 1,
                EmployeeID = 1,
                Quantity = 2,
                PricePerUnit = 750
            };
            db.SellRecords(sale);

            // Резервирование
            var reservation = new Reservation
            {
                RecordID = 1,
                CustomerID = 1,
                Quantity = 1
            };
            db.ReserveRecords(reservation);

            // Получение списка бестселлеров
            var bestSellers = db.GetBestSellers();

            // Получение популярных жанров
            var popularGenres = db.GetPopularGenres();
        }
    }
}
