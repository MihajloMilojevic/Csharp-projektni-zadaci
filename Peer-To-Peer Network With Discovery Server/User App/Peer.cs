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
    internal class Peer
    {
        private string ip;
        private int port;
        private Socket connection;
        private Action<Peer, string> onMessage;
        private Action<Peer> onConnect;
        private Action<Peer> onDisconnect;
        private Thread messagesThread;
        private bool connected = false;

        public Peer(string ipWithPort)
        {
            onMessage = null;
            string[] parts = ipWithPort.Split(':');
            this.ip = parts[0];
            this.port = int.Parse(parts[1]);
            connection = null;
        }
        public Peer(string ip, int port)
        {
            onMessage = null;
            this.ip = ip;
            this.port = port;
            connection = null;
        }
        public Peer(Socket connection)
        {
            this.connection = connection;
            this.connected = true;
            string[] parts = ((IPEndPoint)connection.RemoteEndPoint).ToString().Split(':');
            this.ip = parts[0];
            this.port = int.Parse(parts[1]);
            messagesThread = new Thread(() => ListenForMessages());
            messagesThread.Start();
        }
        public void Connect() {
            if (connected) return;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            connection.Connect(endPoint);
            if (onConnect != null) onConnect(this);
            connected = true;
            messagesThread = new Thread(() => ListenForMessages());
            messagesThread.Start();
        }
        public void Disconnect()
        {
            if (!connected) return;
            connected = false;
            //messagesThread.Abort();
            messagesThread.Interrupt();
            messagesThread = null;
            connection.Shutdown(SocketShutdown.Both);
            connection.Close();
            connection = null;
            if (onDisconnect != null)
            {
                onDisconnect(this);
                onDisconnect = null;
            }
        }
        private void ListenForMessages()
        {
            try
            {
                byte[] Buffer = new byte[connection.SendBufferSize];
                int readByte = 0;
                do
                {
                    try
                    {
                        //Prihvata
                        readByte = connection.Receive(Buffer);

                        //Uzmi podatke
                        byte[] rData = new byte[readByte];
                        Array.Copy(Buffer, rData, readByte);
                        string message = Encoding.UTF8.GetString(rData);
                        if (message.Length == 0) continue;
                        if(onMessage != null)
                            onMessage(this, message);
                    }
                    catch (Exception e)
                    {
                        if (e is ThreadInterruptedException || e is ThreadAbortException) return;
                        Console.WriteLine("Došlo je do greške. Poruka greške: " + e.Message);
                        readByte = 0;
                    }
                }
                while (connected && readByte > 0);
                if(onDisconnect != null)
                {
                    onDisconnect(this);
                    onDisconnect = null;
                } 
            }
            catch (Exception ex)
            {
                if (ex is ThreadInterruptedException || ex is ThreadAbortException) return;
            }
        }
        public void Send(string message)
        {
            if (!connected) return;
            connection.Send(Encoding.UTF8.GetBytes(message));
        }
        public Socket Connection { get { return connection;} }
        public Action<Peer, string> OnMessage 
        { 
            get { return onMessage; } 
            set { onMessage = value; } 
        }
        public Action<Peer> OnConnect
        {
            get { return onConnect; }
            set { onConnect = value; }
        }
        public Action<Peer> OnDisconnect
        {
            get { return onDisconnect; }
            set { onDisconnect = value; }
        }
        public int Port { get { return port; } }
        public string IP { get { return ip; } }
        public bool Connected { get { return connected; } }
    }
}
