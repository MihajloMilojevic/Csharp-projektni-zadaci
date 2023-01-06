using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_App
{
    internal partial class BlockChainDetails : Form
    {
        private Blockchain blockchain;
        private int currentIndex;
        public BlockChainDetails(Blockchain blockchain, int currentIndex)
        {
            InitializeComponent();
            this.blockchain = blockchain;
            this.currentIndex = currentIndex;
            UpdateUI();
        }

        private void genensisBlock_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            UpdateUI();
        }

        private void previousBlock_Click(object sender, EventArgs e)
        {
            currentIndex--;
            UpdateUI();
        }

        private void nextBlock_Click(object sender, EventArgs e)
        {
            currentIndex++;
            UpdateUI();
        }

        private void LastBlock_Click(object sender, EventArgs e)
        {
            currentIndex = blockchain.Count - 1;
            UpdateUI();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            UpdateUI();
        }
        private void UpdateUI()
        {
            currentDifficulty.Text = blockchain.CurrentDifficulty.ToString();
            totalDifficulty.Text = blockchain.TotalDifficulty.ToString();
            count.Text = blockchain.Count.ToString();
            index.Text = blockchain.Chain[currentIndex].Index.ToString();
            timestamp.Text = blockchain.Chain[currentIndex].Timestamp.ToString("dd.MM.yyyy. HH:mm:ss");
            difficulty.Text = blockchain.Chain[currentIndex].Difficulty.ToString();
            nonce.Text = blockchain.Chain[currentIndex].Nonce.ToString();
            data.Text = blockchain.Chain[currentIndex].Data.ToString();
            hash.Text = blockchain.Chain[currentIndex].Hash.ToString();
            previousHash.Text = blockchain.Chain[currentIndex].PreviousHash.ToString();
            if(currentIndex == 0)
            {
                genensisBlock.Enabled = false;
                previousBlock.Enabled = false;
            }
            else
            {
                genensisBlock.Enabled = true;
                previousBlock.Enabled = true;
            }
            if(currentIndex == blockchain.Count - 1)
            {
                nextBlock.Enabled = false;
                LastBlock.Enabled = false;
            }
            else
            {
                nextBlock.Enabled = true;
                LastBlock.Enabled = true;
            }
        }
    }
}
