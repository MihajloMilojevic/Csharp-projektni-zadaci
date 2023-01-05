using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace User_App
{
    internal enum MessageType
    {
        NEW_CHAIN,
        ADD_BLOCK,
        DIFFICULTY_CHANGE,
        NAME_CHANGE
    }
    internal class NetworkMessage
    {
        private MessageType type;
        private string data;
        public NetworkMessage() { }
        public NetworkMessage(MessageType type, string data) 
        {
            this.type = type;
            this.data = data;
        }
        public MessageType Type { get => type; set => type = value; }
        public string Data { get => data; set => data = value; }
        public static string DataStrinigify<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }
        public static T DataParse<T>(string str) {
            return JsonSerializer.Deserialize<T>(str);
        }
        public static NetworkMessage Parse(string str)
        {
            return JsonSerializer.Deserialize<NetworkMessage>(str); 
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
