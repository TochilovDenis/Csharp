using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_ADO.net
{
    class MusicStoreDB
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=MusicStore;
            Integrated Security=SSPI;";
        public void AddRecord(VinylRecord record)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"
                INSERT INTO VinylRecords (Title, Artist, Publisher, TrackCount, GenreID, ReleaseYear, CostPrice, SellingPrice, Quantity)
                VALUES (@Title, @Artist, @Publisher, @TrackCount, @GenreID, @ReleaseYear, @CostPrice, @SellingPrice, @Quantity)",
                    conn);

                cmd.Parameters.AddWithValue("@Title", record.Title);
                cmd.Parameters.AddWithValue("@Artist", record.Artist);
                cmd.Parameters.AddWithValue("@Publisher", record.Publisher);
                cmd.Parameters.AddWithValue("@TrackCount", record.TrackCount);
                cmd.Parameters.AddWithValue("@GenreID", record.GenreId);
                cmd.Parameters.AddWithValue("@ReleaseYear", record.ReleaseYear);
                cmd.Parameters.AddWithValue("@CostPrice", record.CostPrice);
                cmd.Parameters.AddWithValue("@SellingPrice", record.SellingPrice);
                cmd.Parameters.AddWithValue("@Quantity", record.Quantity);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<VinylRecord> SearchRecords(string title = null, string artist = null, string genre = null)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"
                SELECT vr.*, g.Name as GenreName
                FROM VinylRecords vr
                JOIN Genres g ON vr.GenreID = g.GenreID
                WHERE (@Title IS NULL OR vr.Title LIKE '%' + @Title + '%')
                AND (@Artist IS NULL OR vr.Artist LIKE '%' + @Artist + '%')
                AND (@Genre IS NULL OR g.Name LIKE '%' + @Genre + '%')",
                    conn);

                cmd.Parameters.AddWithValue("@Title", title ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Artist", artist ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Genre", genre ?? (object)DBNull.Value);

                conn.Open();
                var records = new List<VinylRecord>();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        records.Add(new VinylRecord
                        {
                            RecordID = (int)reader["RecordID"],
                            Title = reader["Title"].ToString(),
                            Artist = reader["Artist"].ToString(),
                            Publisher = reader["Publisher"].ToString(),
                            TrackCount = (int)reader["TrackCount"],
                            GenreId = (int)reader["GenreID"],
                            ReleaseYear = (int)reader["ReleaseYear"],
                            CostPrice = (decimal)reader["CostPrice"],
                            SellingPrice = (decimal)reader["SellingPrice"],
                            Quantity = (int)reader["Quantity"]
                        });
                    }
                }

                return records;
            }
        }

        public void SellRecords(Sale sale)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Проверяем наличие товара
                        var recordCmd = new SqlCommand(@"
                        SELECT Quantity FROM VinylRecords 
                        WHERE RecordID = @RecordID", conn, transaction);

                        recordCmd.Parameters.AddWithValue("@RecordID", sale.RecordID);

                        var currentQuantity = (int)recordCmd.ExecuteScalar();
                        if (currentQuantity < sale.Quantity)
                            throw new InvalidOperationException("Недостаточно товара на складе");

                        // Выполняем продажу
                        var saleCmd = new SqlCommand(@"
                        INSERT INTO Sales (RecordID, CustomerID, EmployeeID, Quantity, PricePerUnit, SaleDate)
                        VALUES (@RecordID, @CustomerID, @EmployeeID, @Quantity, @PricePerUnit, GETDATE())",
                            conn, transaction);

                        saleCmd.Parameters.AddWithValue("@RecordID", sale.RecordID);
                        saleCmd.Parameters.AddWithValue("@CustomerID", sale.CustomerID);
                        saleCmd.Parameters.AddWithValue("@EmployeeID", sale.EmployeeID);
                        saleCmd.Parameters.AddWithValue("@Quantity", sale.Quantity);
                        saleCmd.Parameters.AddWithValue("@PricePerUnit", sale.PricePerUnit);

                        saleCmd.ExecuteNonQuery();

                        // Обновляем остаток
                        var updateCmd = new SqlCommand(@"
                        UPDATE VinylRecords 
                        SET Quantity = Quantity - @Quantity 
                        WHERE RecordID = @RecordID",
                            conn, transaction);

                        updateCmd.Parameters.AddWithValue("@RecordID", sale.RecordID);
                        updateCmd.Parameters.AddWithValue("@Quantity", sale.Quantity);

                        updateCmd.ExecuteNonQuery();

                        // Обновляем общую сумму покупателя
                        var customerUpdateCmd = new SqlCommand(@"
                        UPDATE Customers 
                        SET TotalSpent = TotalSpent + (@PricePerUnit * @Quantity)
                        WHERE CustomerID = @CustomerID",
                            conn, transaction);

                        customerUpdateCmd.Parameters.AddWithValue("@CustomerID", sale.CustomerID);
                        customerUpdateCmd.Parameters.AddWithValue("@PricePerUnit", sale.PricePerUnit);
                        customerUpdateCmd.Parameters.AddWithValue("@Quantity", sale.Quantity);

                        customerUpdateCmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void ReserveRecords(Reservation reservation)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Проверяем наличие товара
                        var recordCmd = new SqlCommand(@"
                        SELECT Quantity FROM VinylRecords 
                        WHERE RecordID = @RecordID", conn, transaction);

                        recordCmd.Parameters.AddWithValue("@RecordID", reservation.RecordID);

                        var currentQuantity = (int)recordCmd.ExecuteScalar();
                        if (currentQuantity < reservation.Quantity)
                            throw new InvalidOperationException("Недостаточно товара на складе");

                        // Создаем резерв
                        var reserveCmd = new SqlCommand(@"
                        INSERT INTO Reservations (RecordID, CustomerID, Quantity, ExpirationDate)
                        VALUES (@RecordID, @CustomerID, @Quantity, DATEADD(day, 7, GETDATE()))",
                            conn, transaction);

                        reserveCmd.Parameters.AddWithValue("@RecordID", reservation.RecordID);
                        reserveCmd.Parameters.AddWithValue("@CustomerID", reservation.CustomerID);
                        reserveCmd.Parameters.AddWithValue("@Quantity", reservation.Quantity);

                        reserveCmd.ExecuteNonQuery();

                        // Блокируем товар
                        var updateCmd = new SqlCommand(@"
                        UPDATE VinylRecords 
                        SET Quantity = Quantity - @Quantity 
                        WHERE RecordID = @RecordID",
                            conn, transaction);

                        updateCmd.Parameters.AddWithValue("@RecordID", reservation.RecordID);
                        updateCmd.Parameters.AddWithValue("@Quantity", reservation.Quantity);

                        updateCmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<VinylRecord> GetBestSellers()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"
                SELECT TOP 10 vr.*, SUM(s.Quantity) as TotalSold
                FROM VinylRecords vr
                JOIN Sales s ON vr.RecordID = s.RecordID
                GROUP BY vr.RecordID, vr.Title, vr.Artist, vr.Publisher, vr.TrackCount, 
                         vr.GenreID, vr.ReleaseYear, vr.CostPrice, vr.SellingPrice, vr.Quantity
                ORDER BY TotalSold DESC", conn);

                conn.Open();
                var records = new List<VinylRecord>();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        records.Add(new VinylRecord
                        {
                            RecordID = (int)reader["RecordID"],
                            Title = reader["Title"].ToString(),
                            Artist = reader["Artist"].ToString(),
                            Publisher = reader["Publisher"].ToString(),
                            TrackCount = (int)reader["TrackCount"],
                            GenreId = (int)reader["GenreID"],
                            ReleaseYear = (int)reader["ReleaseYear"],
                            CostPrice = (decimal)reader["CostPrice"],
                            SellingPrice = (decimal)reader["SellingPrice"],
                            Quantity = (int)reader["Quantity"]
                        });
                    }
                }

                return records;
            }
        }

        public List<string> GetPopularGenres()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"
                SELECT TOP 10 g.Name, COUNT(s.SaleID) as SalesCount
                FROM Genres g
                JOIN VinylRecords vr ON g.GenreID = vr.GenreID
                JOIN Sales s ON vr.RecordID = s.RecordID
                GROUP BY g.Name
                ORDER BY SalesCount DESC", conn);

                conn.Open();
                var genres = new List<string>();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        genres.Add(reader["Name"].ToString());
                    }
                }

                return genres;
            }
        }
    }
}

