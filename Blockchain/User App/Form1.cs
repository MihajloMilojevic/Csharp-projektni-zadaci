using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Threading;

namespace User_App
{
    public partial class Form1 : Form
    {
        private string SERVER_IP = "127.0.0.1";
        private int SERVER_PORT = 8000;
        private Peer server;
        private P2PNode node = null;
        private Blockchain blockchain = new Blockchain();
        private Thread miningThread;
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
                node = new P2PNode(dsm.IP, blockchain, log, this.UpdateUI);
                node.StartServer();
                UpdateUI();
                foreach(string ip in dsm.Nodes)
                    node.AddPeer(ip);
            };
            try
            {
                server.Connect();
            }
            catch 
            {
                MessageBox.Show("Unable to connect to the discovery server. Check if the server is running and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }  
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("DISCONNECTING");
            if(miningThread != null) miningThread.Abort();
            miningThread = null;
            server.Disconnect();
            if(node != null) node.StopServer();
            //MessageBox.Show("DISCONNECTED SUCCEFULL");
        }
        private void log(string message)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                List<string> list = new List<string>(logBox.Lines);
                list.Add(DateTime.Now.ToString("dd.MM.yyyy. HH:mm:ss") + " - " + message);
                logBox.Lines = list.ToArray();
                UpdateUI();
            }));
        }

        private void changeNameButton_Click(object sender, EventArgs e)
        {
            node.MyName = networkNameTB.Text;
        }
        private void UpdateUI()
        {
            try
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    try
                    {
                        myIpLabel.Text = node.MyIp;
                        myPortLabel.Text = node.MyPort.ToString();
                        networkStatusLabel.Text = node.Status;
                        myPeersLB.Items.Clear();
                        networkNameTB.Text = node.MyName;
                        numbelOfPeersLabel.Text = node.Peers.Count.ToString();
                        foreach (Peer p in node.Peers.ToList())
                            myPeersLB.Items.Add(p.Name);
                        blockchainPreview.Items.Clear();
                        foreach (Block b in blockchain.Chain.ToList())
                            blockchainPreview.Items.Add($"Block #{b.Index}");
                    }
                    catch { }          
                }));
            }
            catch { }
        }

        private void addBlock_Click(object sender, EventArgs e)
        {
            addBlock.Enabled = false;
            log("Mining started");
            miningThread = new Thread(() =>
            {
                Block b = blockchain.AddBlock(newBlockDataTB.Text);
                if (b == null)
                {
                    log("Unable to add block to chain");
                }
                else
                {
                    log("Block added to chain");
                    newBlockDataTB.Text = "";
                }
                addBlock.Invoke(new MethodInvoker(() =>
                {
                    addBlock.Enabled = true;
                }));
            });
            miningThread.Start();
        }
    }
}
