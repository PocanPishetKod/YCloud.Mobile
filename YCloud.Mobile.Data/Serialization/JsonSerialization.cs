using System;
using System.Collections.Generic;
using System.Text;
using Utf8Json;
using YHome.Client.Common;

namespace YCloud.Mobile.Data.Serialization
{
    internal class JsonSerialization : IJsonSerialization
    {
        public T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        public byte[] Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize<T>(obj);
        }
    }
}
