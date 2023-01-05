using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Sever//Server
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint IP =new IPEndPoint (IPAddress.Parse("127.0.0.1"), 8888);
            listenerSocket.Bind(IP);
            int clientNo = 1;
            Console.WriteLine("Server pokrenut...");
            Console.WriteLine("Slušam na: " + IP.ToString());
            while (true)
            {
                listenerSocket.Listen(0);
                Socket clientSocket = listenerSocket.Accept();

                //Niti
                Thread clientThread;
                clientThread = new Thread(() => ClientConnection(clientSocket,clientNo));
                clientThread.Start();
                clientNo++;

            }
            

           
        }
       private static void ClientConnection(Socket clientSocket,int clNr)
        {
            Console.WriteLine("Klijent konektovan  (" + ((IPEndPoint)clientSocket.RemoteEndPoint).ToString() + ")");
            byte[] Buffer = new byte[clientSocket.SendBufferSize];
            int readByte;
            do
            {
                try
                {
                    //Prihvata
                    readByte = clientSocket.Receive(Buffer);

                    //Uzmi podatke
                    byte[] rData = new byte[readByte];
                    Array.Copy(Buffer, rData, readByte);
                    string message = Encoding.UTF8.GetString(rData);
                    if (message.Length == 0) continue;
                    Console.WriteLine("Primio sam: " + message); // ispis u konzoli
                    string odgovor = generateResponse(clientSocket ,message);
                    Console.WriteLine("Odgovorio sam sa: " + odgovor);
                    clientSocket.Send(Encoding.UTF8.GetBytes(odgovor));
                }
                catch(Exception e)
                {
                    Console.WriteLine("Došlo je do greške. Poruka greške: " + e.Message);
                    readByte = 0;
                }
            }
            while (readByte > 0);
            Console.WriteLine("Klijent diskonektovan");
            Console.ReadKey();
        }
        private static string generateResponse(Socket clientSocket, string message)
        {
            if (message.Length == 0) return "Neispravan format poruke";

            char tipPoruke = message.ToUpper()[0];

            string poruka = message.Length > 1 ? message.Substring(1) : "";

            switch (tipPoruke)
            {
                case 'A':
                    return "Zdravo, " + ((IPEndPoint)clientSocket.RemoteEndPoint).ToString();
                case 'B':
                    return "Trenutno vreme: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                case 'C':
                    return "Trenutni radni direktorijum: " + Environment.CurrentDirectory;
                case 'D':
                    return poruka;
                case 'E':
                    return "Ime racunara: " + Environment.MachineName + "\nOS verzija: " + Environment.OSVersion;
                case 'F':
                    return FEN.Prikaz(poruka);
                case 'G':
                    return TripleDES.Encrypt(poruka);
                default:
                    return "Neispravan unos.";
            }
        }
    }
}