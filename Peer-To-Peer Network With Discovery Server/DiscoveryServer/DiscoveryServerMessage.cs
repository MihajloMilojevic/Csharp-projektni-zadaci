using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DiscoveryServer
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
            foreach(Socket s in sockets)
                if(((IPEndPoint)s.RemoteEndPoint).ToString() != ip)
                    nodes.Add(((IPEndPoint)s.RemoteEndPoint).ToString());
        }
        public DiscoveryServerMessage(string ip, List<string> nodes)
        {
            this.ip = ip;
            Nodes = nodes;
        }
    }
}
