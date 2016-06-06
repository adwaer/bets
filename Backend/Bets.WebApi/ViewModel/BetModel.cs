using System;
using System.Runtime.Serialization;
using Bets.Domain;

namespace Bets.WebApi.ViewModel
{
    [DataContract]
    public class BetModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
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

        [DataMember(Name = "result")]
        public BetResultViewModel Result { get; set; }

        public Bet ConvertToBet()
        {
            return new Bet
            {
                Id = Id,
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

        public static BetModel ConvertFromEntity(Bet bet)
        {
            return new BetModel
            {
                Id = bet.Id,
                Game = bet.Game,
                Tournament = bet.Tournament,
                Forecast = bet.Forecast,
                Amount = bet.Amount,
                Content = bet.Content,
                Coefficient = bet.Coefficient,
                GameStartDate = bet.GameStartDate,
                ShowDate = bet.ShowDate,
                Result = bet.Result == null ? null: new BetResultViewModel
                {
                    Id = bet.Result.Id,
                    Gain = bet.Result.Gain,
                    Comment = bet.Result.Comment,
                    Socceed = bet.Result.Soceed,
                    MakeDate = bet.Result.MakeDate
                }
            };
        }

    }
}
