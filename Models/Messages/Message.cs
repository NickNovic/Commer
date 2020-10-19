using System;

namespace Models.Messages
{
    public class Message
    { 
        public DateTime Time { get; set; }
        public MessageType Type { get; set; }
    }
}