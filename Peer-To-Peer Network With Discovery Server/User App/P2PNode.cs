using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_App
{
    internal class P2PNode
    {
        private List<Peer> peers;
        private string myIp;
        private int myPort;
        private Thread myServerThread;
        private Socket myServerSocket;
        private bool serverRunning;
        public P2PNode(string ip, int port)
        {
            this.myIp= ip;
            this.myPort= port;
            peers = new List<Peer>();
            StartServer();
        }
        public P2PNode(string ipWithPort) 
        {
            string[] parts = ipWithPort.Split(':'); 
            myIp = parts[0];    
            myPort = int.Parse(parts[1]);
            peers = new List<Peer>();
            StartServer();
        }
        public void StartServer()
        {
            serverRunning= true;
            myServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            myServerSocket.Bind(new IPEndPoint(IPAddress.Parse(myIp), myPort));
            myServerThread = new Thread(() => ListenForConnections());
            myServerThread.Start();
        }
        private void ListenForConnections()
        {
            while (serverRunning)
            {
                try
                {
                    myServerSocket.Listen(0);
                    Socket clientSocket = myServerSocket.Accept();
                    if (!serverRunning) break;
                    AddPeer(clientSocket);
                }
                catch (ThreadInterruptedException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }
        public void Broadcast(string message)
        {
            foreach (Peer peer in peers.ToList())
                peer.Send(message);
        }
        public void RemovePeer(Peer peer)
        {
            peers.Remove(peer);
        }
        public void AddPeer(string ipWithPort)
        {
            Peer p = new Peer(ipWithPort)
            {
                OnMessage = (peer, msg) => MessageBox.Show(msg, $"{peer.IP}:{peer.Port} sends: "),
                OnDisconnect = (peer) => { RemovePeer(peer); MessageBox.Show($"{peer.IP}:{peer.Port} has disconnected "); },
                OnConnect = (peer) => MessageBox.Show($"new peer connected from {peer.IP}:{peer.Port}")
            };
            p.Connect();
            peers.Add(p);
        }
        public void AddPeer(string ip, int port)
        {
            Peer p = new Peer(ip, port)
            {
                OnMessage = (peer, msg) => MessageBox.Show(msg, $"{peer.IP}:{peer.Port} sends: "),
                OnDisconnect = (peer) => RemovePeer(peer),
                OnConnect = (peer) => MessageBox.Show($"new peer connected from {peer.IP}:{peer.Port}")
            };
            p.Connect();
            peers.Add(p);
        }
        public void AddPeer(Socket socket)
        {
            Peer p = new Peer(socket)
            {
                OnMessage = (peer, msg) => MessageBox.Show(msg, $"{peer.IP}:{peer.Port} sends: "),
                OnDisconnect = (peer) => RemovePeer(peer),
                OnConnect = (peer) => MessageBox.Show($"new peer connected from {peer.IP}:{peer.Port}")
            };
            p.Connect();
            peers.Add(p);
        }
        public void AddPeer(Peer peer)
        {
            peers.Add(peer);
        }
        public void StopServer()
        {
            foreach(Peer peer in peers.ToList()) peer.Disconnect();
            serverRunning= false;
            myServerThread.Interrupt();
            myServerThread = null;
            myServerSocket.Close();
            myServerSocket = null;
        }
    }
}
