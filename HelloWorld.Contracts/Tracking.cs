using Newtonsoft.Json;
using System;

namespace HelloWorld.Contracts
{
    [JsonObject(MemberSerialization.OptIn)]
    [Serializable]
    public class Tracking<T>
        where T : struct
    {
        public Tracking()
        {
            ID = default(T);
            CreatedDate = DateTime.Now;
            IsDeleted = false;
        }

        public DateTime CreatedDate { get; set; }

        public T ID { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}