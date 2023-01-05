using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace User_App
{
    internal class DiscoveryServerMessage
    {
        private string ip;
        private List<string> nodes;
        public string IP { get { return ip; } set { ip = value; } }
        public List<string> Nodes { get { return nodes; } set { nodes = value; } }
        public DiscoveryServerMessage() 
        {
            ip = "";
            nodes = new List<string>();
        }
        public DiscoveryServerMessage(string ip, List<Socket> sockets)
        {
            this.ip = ip;
            this.nodes = new List<string>();
            foreach (Socket s in sockets)
                nodes.Add(((IPEndPoint)s.RemoteEndPoint).ToString());
        }
        public DiscoveryServerMessage(string ip, List<string> nodes)
        {
            this.ip = ip;
            Nodes = nodes;
        }
    }
}
