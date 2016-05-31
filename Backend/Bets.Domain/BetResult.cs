using System;

namespace Bets.Domain
{
    public class BetResult : EntityBase<int>
    {
        /// <summary>
        /// Успешность
        /// </summary>
        public bool? Soceed { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Выигрыш
        /// </summary>
        public decimal Gain { get; set; }
        public DateTime MakeDate { get; set; }
    }
}
