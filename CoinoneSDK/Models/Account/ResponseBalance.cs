using System;
using System.Collections.Generic;
using CoinoneSDK.Models.Base;
using Newtonsoft.Json;

namespace CoinoneSDK.Models.Account
{
    public class ResponseBalance : CoinoneResponseBase
    {
        public ResponseBalance()
        {
        }

        public ResponseBalance(string response) : base(response)
        {

        }


        [JsonProperty("normalWallets")]
        public List<NormalWallet> NormalWallets { get; set; }

        public List<Dictionary<string, BalanceItem>> DicResult { get; set; }

        [JsonProperty("pod")]
        public BalanceItem Pod { get; set; }
    }


    public class NormalWallet
    {
        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class BalanceItem
    {
        [JsonProperty("avail")]
        public string Avail { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }
    }


}
