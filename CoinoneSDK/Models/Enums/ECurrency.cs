using System.Runtime.Serialization;

namespace CoinoneSDK.Models.Enums
{

    public enum ECurrency
    {
        [EnumMember(Value ="BTC")]
        BTC,

        [EnumMember(Value = "POD")]
        POD
    }
}