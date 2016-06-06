using System;
using System.Runtime.Serialization;
using Bets.Domain;

namespace Bets.WebApi.ViewModel
{
    [DataContract]
    public class BetResultViewModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Успешность
        /// </summary>
        [DataMember(Name = "socceed")]
        public bool? Socceed { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        [DataMember(Name = "comment")]
        public string Comment { get; set; }
        /// <summary>
        /// Выигрыш
        /// </summary>
        [DataMember(Name = "gain")]
        public decimal Gain { get; set; }
        [DataMember(Name = "makeDate")]
        public DateTime MakeDate { get; set; }

    }
}
