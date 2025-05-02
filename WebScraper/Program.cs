class Program
{
    static HttpClient httpClient = new HttpClient();

    static async Task Main()
    {
        List<string> addresses = new List<string>();
        List<string> addressesLevel2 = new List<string>();

        Console.Write("Введите адрес: ");
        string baseUrl = Console.ReadLine();

        try
        {
            string content = await httpClient.GetStringAsync(baseUrl);

            // Поиск ссылок первого уровня
            int index = 0;
            while ((index = content.IndexOf("href=\"", index)) != -1)
            {
                index += 7;
                int endIndex = content.IndexOf("", index);
                if (endIndex > 0)
                {
                    string link = content.Substring(index, endIndex - index);
                    addresses.Add(link);
                }
            }

            addresses = addresses.Distinct().ToList();

            // Поиск страниц с глубиной 2
            foreach (string addr in addresses)
            {
                try
                {
                    string fullUrl = baseUrl + addr;
                    string level2Content = await httpClient.GetStringAsync(fullUrl);

                    int level2Index = 0;
                    while ((level2Index = level2Content.IndexOf("href=\"", level2Index)) != -1)
                    {
                        level2Index += 7;
                        int level2EndIndex = level2Content.IndexOf("", level2Index);
                        if (level2EndIndex > 0)
                        {
                            string level2Link = level2Content.Substring(level2Index, level2EndIndex - index);
                            addressesLevel2.Add(level2Link);
                        }
                    }

                    Console.WriteLine($"Обработана страница: {addr}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка при обработке {baseUrl + addr}: {e.Message}");
                }
            }

            Console.WriteLine("\nВывод страниц с глубиной 2:");
            foreach (string addr2 in addressesLevel2.Distinct())
            {
                Console.WriteLine(addr2);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при получении начальной страницы: {e.Message}");
        }
    }
}