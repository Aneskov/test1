using Newtonsoft.Json;

namespace Ayes.Test.Domain
{
    class Card
    {
        [JsonProperty("suit")]
        public ECardSuit Suite { get; private set; }
        [JsonProperty("value")]
        public ECardValue Value { get; private set; }

        public override string ToString() => $"{Value} of {Suite}";
    }
}
