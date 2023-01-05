using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_App
{
    public partial class Form1 : Form
    {
        private string SERVER_IP = "127.0.0.1";
        private int SERVER_PORT = 8000;
        private Peer server;
        private P2PNode node;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            server = new Peer(SERVER_IP, SERVER_PORT);
            DiscoveryServerMessage dsm = null;
            server.OnMessage = (_, message) => { 
                dsm = JsonSerializer.Deserialize<DiscoveryServerMessage>(message);
                node = new P2PNode(dsm.IP);
                foreach(string ip in dsm.Nodes)
                {
                    node.AddPeer(ip);
                }
                //node.Broadcast("HELLO???");
            };
            try
            {
                server.Connect();
            }
            catch 
            {
                MessageBox.Show("Unable to connect to the discovery server. Check if the server is running and try again");
                Close();
                return;
            }  
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("DISCONNECTING");
            server.Disconnect();
            node.StopServer();
            //MessageBox.Show("DISCONNECTED SUCCEFULL");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            node.Broadcast(textBox1.Text);
        }
    }
}
