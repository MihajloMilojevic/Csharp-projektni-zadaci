using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace User_App
{
    internal class P2PNode
    {
        private List<Peer> peers;
        private string myIp;
        private int myPort;
        private string myName;
        private Thread myServerThread;
        private Socket myServerSocket;
        private bool serverRunning;
        private Blockchain blockchain;
        private Controller controler;
        private string status;
        private Action<string> log;
        private Action updateUI;
        public P2PNode(string ip, int port, Blockchain blockchain, Action<string> log, Action updateUI)
        {
            status = "disconneced";
            this.myIp = ip;
            this.myPort = port;
            myName = $"{myIp}:{myPort}";
            peers = new List<Peer>();
            this.blockchain = blockchain;
            this.controler = new Controller(this, log, blockchain);
            this.log = log;
            this.updateUI = updateUI;
            AddBlockchainEvents();
        }
        public P2PNode(string ipWithPort, Blockchain blockchain, Action<string> log, Action updateUI)
        {
            status = "disconneced";
            string[] parts = ipWithPort.Split(':'); 
            myIp = parts[0];    
            myPort = int.Parse(parts[1]);
            myName = $"{myIp}:{myPort}";
            peers = new List<Peer>();
            this.blockchain = blockchain;
            this.controler = new Controller(this, log, blockchain);
            this.log = log;
            this.updateUI = updateUI;
            AddBlockchainEvents();
        }
        public void StartServer()
        {
            serverRunning= true;
            myServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            myServerSocket.Bind(new IPEndPoint(IPAddress.Parse(myIp), myPort));
            myServerThread = new Thread(() => ListenForConnections());
            myServerThread.Start();
            status = "connected";
        }
        private void AddBlockchainEvents()
        {
            blockchain.OnBlockAdd = block =>
            {
                this.Broadcast(new NetworkMessage[]
                {
                    new NetworkMessage(
                        MessageType.ADD_BLOCK,
                        NetworkMessage.DataStrinigify<Block>(block)
                )
                });
            };
            blockchain.OnDifficultyChange = diff =>
            {
                this.Broadcast(new NetworkMessage[]
                {
                    new NetworkMessage(
                        MessageType.DIFFICULTY_CHANGE,
                        NetworkMessage.DataStrinigify<int>(diff)
                )
                });
            };
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
                    updateUI();
                    //Peer peer = new Peer(clientSocket);
                    //log($"New peer connected from {peer.IP}:{peer.Port}");
                    //peer.Send(new NetworkMessage(MessageType.NAME_CHANGE, NetworkMessage.DataStrinigify(this.MyName)).ToString());
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
        public void Broadcast(NetworkMessage[] messages)
        {
            List<NetworkMessage> list = new List<NetworkMessage>(messages);
            string str = JsonSerializer.Serialize(list);
            foreach (Peer peer in peers.ToList())
                peer.Send(str);
        }
        public void RemovePeer(Peer peer)
        {
            peers.Remove(peer);
        }
        public Peer SetPeerEvents(Peer p)
        {
            p.OnMessage = controler.handleMassageReceive;
            p.OnDisconnect = controler.handleNodeDisconnection;
            p.OnConnect = controler.handleNodeConnection;
            return p;
        }
        public void AddPeer(string ipWithPort)
        {
            Peer p = SetPeerEvents(new Peer(ipWithPort));
            p.Connect();
            peers.Add(p);
        }
        public void AddPeer(string ip, int port)
        {
            Peer p = SetPeerEvents(new Peer(ip, port));
            p.Connect();
            peers.Add(p);
        }
        public void AddPeer(Socket socket)
        {
            Peer p = SetPeerEvents(new Peer(socket));
            p.Connect();
            peers.Add(p);
        }
        public void AddPeer(Peer peer)
        {
            peers.Add(peer);
        }
        public void StopServer()
        {
            status = "disconnecting";
            foreach (Peer peer in peers.ToList()) peer.Disconnect();
            serverRunning= false;
            myServerThread.Interrupt();
            myServerThread = null;
            myServerSocket.Close();
            myServerSocket = null;
        }
        public List<Peer> Peers { get => peers; }
        public string MyIp { get => myIp; }
        public int MyPort { get => myPort; }
        public string Status { get => status; set => status = value; }
        public string MyName { 
            get => myName; 
            set
            {
                myName = value;
                this.Broadcast(new NetworkMessage[] { new NetworkMessage(MessageType.NAME_CHANGE, NetworkMessage.DataStrinigify(myName)) });
                log($"You have changed yout name to {myName}");
            }
        }
    }
}
