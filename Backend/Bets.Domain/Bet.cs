using System;

namespace Bets.Domain
{
    public class Bet: EntityBase<int>
    {
        /// <summary>
        /// Игра
        /// </summary>
        public string Game { get; set; }
        /// <summary>
        /// Турнир
        /// </summary>
        public string Tournament { get; set; }
        /// <summary>
        /// Прогноз
        /// </summary>
        public string Forecast { get; set; }
        /// <summary>
        /// Сумма ставки
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Коэффициент
        /// </summary>
        public decimal Coefficient { get; set; }
        /// <summary>
        /// Начало игры
        /// </summary>
        public DateTime GameStartDate { get; set; }
        /// <summary>
        /// Дата начала показа
        /// </summary>
        public DateTime ShowDate { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime MakeDate { get; set; }

        public virtual BetResult Result { get; set; }
    }
}
