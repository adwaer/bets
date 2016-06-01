using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Bets.Dal;
using Bets.Domain;
using Microsoft.Owin.Hosting;
using Bets.WebApi;

namespace Bets.Host
{
    public class Program
    {
        private static void Main()
        {
            ParseCsv();
            return;
            var host = ConfigurationManager.AppSettings["host"];
            using (WebApp.Start<Startup>(host))
            {

                Console.WriteLine($"Starting host for uri: {host}");
                Console.WriteLine();

                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }

        private static void ParseCsv()
        {
            var ctx = new DefaultCtx();
            if (ctx.Bets
                .Any())
            {
                return;
            }

            using (var reader = File.OpenText("bets.csv"))
            {
                reader.ReadLine();
                var line = reader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {

                    var columns = line.Split(';');
                    if (string.IsNullOrEmpty(columns[0]))
                        break;

                    var date = DateTime.Parse(columns[0]);
                    var eventName = columns[1];
                    var forecast = columns[2];
                    var coef = decimal.Parse(columns[3]);
                    var amount = decimal.Parse(columns[5]);
                    var result = columns[6];
                    var gain = decimal.Parse(columns[7]);
                    var comment = $"{columns[9]}. Ссылки:";
                    for (int i = 10; i < columns.Length; i++)
                    {
                        comment += Environment.NewLine + columns[i];
                    }

                    var bet = new Bet
                    {
                        MakeDate = DateTime.UtcNow,
                        ShowDate = date,
                        Tournament = eventName,
                        Game = eventName,
                        Amount = amount,
                        Coefficient = coef,
                        Content = comment,
                        Forecast = forecast,
                        GameStartDate = date
                    };
                    if (!string.IsNullOrEmpty(result))
                    {
                        bet.Result = new BetResult
                        {
                            MakeDate = DateTime.UtcNow,
                            Comment = result,
                            Gain = gain
                        };
                        if (gain != amount)
                        {
                            bet.Result.Soceed = gain > amount;
                        }
                    }
                    ctx.Bets.Add(bet);

                    line = reader.ReadLine();
                }
            }
            ctx.SaveChanges();

            Console.WriteLine("done");
            Console.ReadKey();
        }
    }

}
