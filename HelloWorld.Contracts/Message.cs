using Newtonsoft.Json;
using System;

namespace HelloWorld.Contracts
{
    [JsonObject(MemberSerialization.OptIn)]
    [Serializable]
    public class Message : Tracking<int>
    {
        public string MessageString { get; set; }
    }
}