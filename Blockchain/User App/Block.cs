using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_App
{
    internal class Block
    {
        public static SHA256 sha256 = SHA256.Create();
        public static string CalculateHash(string text)
        {
            return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
        }
        private int index;
        private string data;
        private DateTime timestamp;
        private int nonce;
        private int difficulty;
        private string hash;
        private string previousHash;
        public Block(int index, string data, string previousHash)
        {
            this.index = index;
            this.data = data;
            this.timestamp = DateTime.Now;
            this.nonce = 0;
            this.difficulty = 0;
            this.previousHash = previousHash;
            this.hash = CalculateHash();
        }
        public int Index 
        { 
            get => index;
            set
            {
                index = value;
            }
        }
        public string Data 
        { 
            get => data;
            set
            {
                data = value;
            }
        }
        public DateTime Timestamp 
        { 
            get => timestamp; 
            set
            {
                timestamp = value;
            }
        }
        public int Nonce 
        { 
            get => nonce; 
            set
            {
                nonce = value;
            }
        }
        public int Difficulty 
        { 
            get => difficulty;
            set
            {
                difficulty = value;
            }
        }
        public string Hash 
        { 
            get => hash;
            set
            {
                hash = value;
            }
        }
        public string PreviousHash 
        { 
            get => previousHash;
            set
            {
                previousHash = value;
            }
        }
        public string CalculateHash()
        {
            return Block.CalculateHash(
                    index.ToString()+
                    data.ToString() + 
                    timestamp.ToString() +
                    previousHash.ToString() + 
                    difficulty.ToString() + 
                    nonce.ToString()
                );
        }
        public void Mine(int difficulty)
        {
            this.difficulty = difficulty;
            this.hash = this.CalculateHash();
            while (!DifficultyCheck())
            {
                nonce++;
                hash = CalculateHash();
            }
        }
        public bool Valid(Block previousBlock)
        {
            if (previousBlock == null)
                return (
                    this.CalculateHash() == this.hash &&
                    this.DifficultyCheck()
                );
            return (
                this.CalculateHash() == this.hash &&
                this.DifficultyCheck() &&
                this.index == previousBlock.index + 1 &&
                this.previousHash == previousBlock.hash
            );
        }
        private bool DifficultyCheck()
        {
            char[] arr = new char[difficulty];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = '0';
            return this.hash.Substring(0, difficulty).ToCharArray().SequenceEqual(arr);
        }
        public override string ToString()
        {
            return (
                    "Index: " + index.ToString() + "\n" +
                    "Data: " + data.ToString() + "\n" +
                    "Timestamp: " + timestamp.ToString() + "\n" +
                    "Difficulty: " + difficulty.ToString() + "\n" +
                    "Nonce: " + nonce.ToString() + "\n" +
                    "Hash: " + hash.ToString() + "\n" +
                    "Previous Hash: " + previousHash.ToString()
                ); ;
        }
    }
}
