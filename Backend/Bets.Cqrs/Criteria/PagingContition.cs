using System.Runtime.Serialization;

namespace Bets.Cqrs.Criteria
{
    public class PagingContition
    {
        [DataMember(Name = "page")]
        public int Page { get; set; }
        [DataMember(Name = "count")]
        public int Count { get; set; }
    }
}
