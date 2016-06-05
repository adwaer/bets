using System;
using System.Runtime.Serialization;
using Bets.Domain;

namespace Bets.WebApi.ViewModel
{
    public class BetAddModel
    {
        /// <summary>
        /// Игра
        /// </summary>
        [DataMember(Name = "game", IsRequired = true)]
        public string Game { get; set; }
        /// <summary>
        /// Турнир
        /// </summary>
        [DataMember(Name = "tournament", IsRequired = true)]
        public string Tournament { get; set; }
        /// <summary>
        /// Прогноз
        /// </summary>
        [DataMember(Name = "forecast", IsRequired = true)]
        public string Forecast { get; set; }
        /// <summary>
        /// Сумма ставки
        /// </summary>
        [DataMember(Name = "amount", IsRequired = true)]
        public decimal Amount { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        [DataMember(Name = "content", IsRequired = true)]
        public string Content { get; set; }
        /// <summary>
        /// Коэффициент
        /// </summary>
        [DataMember(Name = "coef", IsRequired = true)]
        public decimal Coefficient { get; set; }
        /// <summary>
        /// Начало игры
        /// </summary>
        [DataMember(Name = "gameStartDate", IsRequired = true)]
        public DateTime GameStartDate { get; set; }
        /// <summary>
        /// Дата начала показа
        /// </summary>
        [DataMember(Name = "showDate", IsRequired = true)]
        public DateTime ShowDate { get; set; }

        public Bet ConvertToBet()
        {
            return new Bet
            {
                Game = Game,
                Tournament = Tournament,
                Forecast = Forecast,
                Amount = Amount,
                Content = Content,
                Coefficient = Coefficient,
                GameStartDate = GameStartDate,
                ShowDate = ShowDate
            };
        }
    }
}
