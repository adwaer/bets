using System;
using System.Runtime.Serialization;

namespace Bets.Cqrs.Criteria
{
    public class BetCondition : PagingContition
    {
        [DataMember(Name = "startDate")]
        public DateTime StartDate { get; set; }
        [DataMember(Name = "endDate")]
        public DateTime EndDate { get; set; }
    }
}