using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_App
{
    internal class Controller
    {
        private P2PNode node;
        private Blockchain blockchain;
        private Action<string> log;
        public Controller(P2PNode node, Action<string> log, Blockchain blockchain) 
        {
            this.node = node;
            this.log = log;
            this.blockchain = blockchain;
        }
        public void handleMassageReceive(Peer peer, string msg)
        {
            try
            {
                List<NetworkMessage> messages = JsonSerializer.Deserialize<List<NetworkMessage>>(msg);
                foreach (NetworkMessage message in messages)
                {
                    switch (message.Type)
                    {
                        case MessageType.ADD_BLOCK:
                            Block block = NetworkMessage.DataParse<Block>(message.Data);
                            blockchain.UpdateChain(block);
                            log($"{peer.Name} added new block to the chain");
                            break;
                        case MessageType.DIFFICULTY_CHANGE:
                            int newDifficulty = NetworkMessage.DataParse<int>(message.Data);
                            blockchain.CurrentDifficulty = newDifficulty;
                            log($"{peer.Name} changed difficulty of the chain");
                            break;
                        case MessageType.NEW_CHAIN:
                            List<Block> newChain = NetworkMessage.DataParse<List<Block>>(message.Data);
                            Blockchain testBlockchain = new Blockchain();
                            testBlockchain.Chain = newChain;
                            if (testBlockchain.Valid() && testBlockchain.TotalDifficulty > blockchain.TotalDifficulty)
                            {
                                blockchain.Chain = newChain;
                                log($"{peer.Name} sent new chain that got accepted and is now current chain");
                            }
                            else
                                log($"{peer.Name} sent new chain that got rejected");
                            break;
                        case MessageType.NAME_CHANGE:
                            string name = NetworkMessage.DataParse<string>(message.Data);
                            string oldName = peer.Name;
                            peer.Name = name;
                            log($"{oldName} changed its name to {name}");
                            break;
                        default:
                            log($"{peer.Name} sent message of unknown tyoe");
                            break;
                    }
                }
            }
            catch(Exception e) 
            {
                log($"{peer.Name} send a message that has thrown an error: {e.Message}");
            }
        }
        public void handleNodeConnection(Peer peer)
        {
            List<NetworkMessage> list = new List<NetworkMessage>(new NetworkMessage[] {
                new NetworkMessage(MessageType.NAME_CHANGE, NetworkMessage.DataStrinigify(node.MyName)),
                new NetworkMessage(MessageType.DIFFICULTY_CHANGE, NetworkMessage.DataStrinigify(blockchain.CurrentDifficulty)),
                new NetworkMessage(MessageType.NEW_CHAIN, NetworkMessage.DataStrinigify(blockchain.Chain))
            });
            peer.Send(JsonSerializer.Serialize(list));
            log($"New peer connected from {peer.IP}:{peer.Port}");
        }
        public void handleNodeDisconnection(Peer peer)
        {
            node.RemovePeer(peer);
            log($"{peer.Name} has disconnected");
        }
    }
}