using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_App
{
    internal class Blockchain
    {
        private List<Block> chain;
        private int currentDifficulty;
        private int blockInsersionInterval;
        private int difficultyCorrectionInterval;
        private int addedBlocks;
        private Action<int> onDifficultyChange;
        private Action<Block> onBlockAdd;
        public Blockchain()
        {
            chain = new List<Block>();
            currentDifficulty = 1;
            blockInsersionInterval = 10;
            difficultyCorrectionInterval = 5;
            onDifficultyChange = null;
            onBlockAdd = null;
            addedBlocks = 0;
        }
        public List<Block> Chain { get => chain; set => chain = value; }
        public int CurrentDifficulty { get => currentDifficulty; set => currentDifficulty = value; }
        [JsonIgnore]
        public int TotalDifficulty { 
            get { 
                int s = 0; 
                foreach (Block b in chain.ToArray()) 
                    s += b.Difficulty; 
                return s; 
            } 
        }
        public int BlockInsertionInterval { get => blockInsersionInterval; set => blockInsersionInterval = value; }
        public int DifficultyCorrectionInterval { get => difficultyCorrectionInterval; set => difficultyCorrectionInterval = value; }
        [JsonIgnore]
        public Action<int> OnDifficultyChange { get => onDifficultyChange; set => onDifficultyChange = value; }
        [JsonIgnore]
        public Action<Block> OnBlockAdd { get => onBlockAdd; set => onBlockAdd = value; }
        [JsonIgnore]
        public int Count { get => chain.Count; }
        [JsonIgnore]
        public Block Last { get => Count != 0 ? chain[chain.Count - 1] : null; }
        [JsonIgnore]
        public Block Genesis { get => Count != 0 ? chain[0] : null; }
        public Block AddBlock(string data)
        {
            Block block = new Block(Count, data, Count != 0 ? Last.Hash : "0");
            block.Mine(currentDifficulty);
            //MessageBox.Show("BLOCK MINED");
            //if (Last != null && ((DateTime.Now - Last.Timestamp)).TotalSeconds < blockInsersionInterval) return null;
            //MessageBox.Show("INTERVAL VALIDATION COMPLETED");
            if (!block.Valid(Last)) return null;
            //MessageBox.Show(block.ToString());
            chain.Add(block);
            if(onBlockAdd != null) onBlockAdd(block);
            addedBlocks++;
            if(addedBlocks == difficultyCorrectionInterval) ChangeDifficulty();
            return block;
        }
        public Block UpdateChain(Block block)
        {
            if (!block.Valid(Last)) return null;
            Chain.Add(block);
            addedBlocks++;
            if(addedBlocks == difficultyCorrectionInterval)
                ChangeDifficulty();
            return block;
        }
        public void ChangeDifficulty()
        {
            if(Count - difficultyCorrectionInterval < 0) return;
            addedBlocks = 0;
            Block previousAdjustmentBlock = chain[Count - difficultyCorrectionInterval];
            int timeExpected = blockInsersionInterval * difficultyCorrectionInterval;
            double timeTaken = (Last.Timestamp - previousAdjustmentBlock.Timestamp).TotalSeconds;
            if (timeTaken < (timeExpected / 2.0))
            {
                CurrentDifficulty = previousAdjustmentBlock.Difficulty + 1;
                if (onDifficultyChange != null) onDifficultyChange(currentDifficulty);
            }
            else if (timeTaken > (timeExpected * 2))
            {
                CurrentDifficulty = previousAdjustmentBlock.Difficulty - 1;
                if (onDifficultyChange != null) onDifficultyChange(currentDifficulty);
            }
        }
        public bool Valid()
        {
            for (int i = 1; i < Count; i++)
                if (!chain[i].Valid(chain[i - 1]))
                    return false;
            return true;
        }
        public void Copy(Blockchain sourse)
        {
            this.chain = sourse.chain;
            this.currentDifficulty= sourse.currentDifficulty;
            this.blockInsersionInterval = sourse.blockInsersionInterval;
            this.difficultyCorrectionInterval= sourse.difficultyCorrectionInterval;
        }
    }
}
