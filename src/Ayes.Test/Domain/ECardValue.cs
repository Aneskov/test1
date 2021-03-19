using System.Runtime.Serialization;

namespace Ayes.Test.Domain
{
    enum ECardValue
    {
        [EnumMember(Value = "2")]
        Two,
        [EnumMember(Value = "3")]
        Three,
        [EnumMember(Value = "4")]
        Four,
        [EnumMember(Value = "5")]
        Five,
        [EnumMember(Value = "6")]
        Six,
        [EnumMember(Value = "7")]
        Seven,
        [EnumMember(Value = "8")]
        Eight,
        [EnumMember(Value = "9")]
        Nine,
        [EnumMember(Value = "10")]
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
