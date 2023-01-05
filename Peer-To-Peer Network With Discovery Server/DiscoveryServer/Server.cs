using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace DiscoveryServer
{
    public partial class Server : Form
    {
        private Thread serverThread;
        private List<Socket> connectedNodes = new List<Socket>();
        private string ip = "127.0.0.1";
        private int port = 8000;
        private bool serverRunning = false;
        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            
            serverThread = new Thread(() => this.runServer());
            serverThread.Start();
        }
        private void log(string msg)
        {
            logLB.Invoke(new MethodInvoker(() => { 
                logLB.Items.Add(msg);
                logLB.SelectedIndex = logLB.Items.Count - 1;
                logLB.SelectedIndex = -1;
            }));
        }
        private void update() 
        {
            ipLabel.Invoke(new MethodInvoker(() => { ipLabel.Text = ip; }));
            portLabel.Invoke(new MethodInvoker(() => { portLabel.Text = port.ToString(); }));
            numberOfNodesLabel.Invoke(new MethodInvoker(() => { numberOfNodesLabel.Text = connectedNodes.Count.ToString(); }));
            nodesLB.Invoke(new MethodInvoker(() =>
            {
                nodesLB.Items.Clear();
                foreach (Socket node in connectedNodes)
                    nodesLB.Items.Add(((IPEndPoint)node.RemoteEndPoint).ToString());
            }));
              
        }
        private string CurrentTimeStamp
        {
            get { return DateTime.Now.ToString("dd.MM.yyyy. hh:mm:ss"); }
        }
        private void runServer()
        {
            try
            {
                Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint IP = new IPEndPoint(IPAddress.Parse(ip), port);
                try
                {
                    listenerSocket.Bind(IP);
                    log(
                        CurrentTimeStamp + " - " +
                        "Server started on: " +
                        ip + ":" + port
                    );
                    update();
                    serverRunning = true;
                }
                catch (Exception)
                {
                    log(
                        CurrentTimeStamp + " - " +
                        "Unable to start the server. Server is probably already running"
                    );
                    serverRunning = false;
                    return;
                }
                while (serverRunning)
                {
                    try
                    {
                        listenerSocket.Listen(0);
                        Socket clientSocket = listenerSocket.Accept();
                        if (!serverRunning) break;
                        log(
                        CurrentTimeStamp + " - " +
                            "New node connected from: " +
                            ((IPEndPoint)clientSocket.RemoteEndPoint).ToString()
                        );
                        connectedNodes.Add(clientSocket);
                        update();
                        Thread clientThread;
                        clientThread = new Thread(() => ClientConnection(clientSocket));
                        clientThread.Start();
                    }
                    catch (ThreadInterruptedException)
                    {
                        log(CurrentTimeStamp + " - " + "Server stopped");
                    }
                    catch (Exception ex)
                    {
                        log(CurrentTimeStamp + " - " + "Error: " + ex.Message);
                    }
                }
            }
            catch (ThreadInterruptedException )
            {
                log(CurrentTimeStamp + " - " + "Server stopped");
            }
        }
        private void ClientConnection(Socket client)
        {
            string clientIpEndPoint = ((IPEndPoint)client.RemoteEndPoint).ToString();
            DiscoveryServerMessage messageObject = new DiscoveryServerMessage(clientIpEndPoint, connectedNodes);
            string messageString = JsonSerializer.Serialize<DiscoveryServerMessage>(messageObject);
            client.Send(Encoding.UTF8.GetBytes(messageString));
            byte[] Buffer = new byte[client.SendBufferSize];
            int readByte;
            do
            {
                try
                {
                    //Prihvata
                    readByte = client.Receive(Buffer);

                    //Uzmi podatke
                    byte[] rData = new byte[readByte];
                    Array.Copy(Buffer, rData, readByte);
                    string message = Encoding.UTF8.GetString(rData);
                    if (message.Length == 0) continue;
                    //Console.WriteLine("Primio sam: " + message); // ispis u konzoli
                    //string odgovor = generateResponse(clientSocket ,message);
                    //Console.WriteLine("Odgovorio sam sa: " + odgovor);
                    //clientSocket.Send(Encoding.UTF8.GetBytes(odgovor));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Došlo je do greške. Poruka greške: " + e.Message);
                    readByte = 0;
                }
            }
            while (readByte > 0);
            connectedNodes.Remove(client);
            log(CurrentTimeStamp + " - " + "Client from: " + clientIpEndPoint + " disconnected");
            update();
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                serverRunning = false;
                Socket clientToUnlockAccept = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientToUnlockAccept.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
                log(CurrentTimeStamp + " - " + "Stopping the server");
                serverThread.Interrupt();
                //serverThread.Abort();
                serverThread = null;
            }
            catch
            {
                log(CurrentTimeStamp + " - " + "Unable to stop the server");
                e.Cancel = true;
            }
        }
    }
}
