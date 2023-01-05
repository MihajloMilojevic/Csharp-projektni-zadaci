using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Klijent
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Ovo je klijent");
                Socket master = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
                master.Connect(IP);
                byte[] buffer = new byte[master.ReceiveBufferSize];
                Console.Write("Odaberi tip poruke (A, B, C, D, E, F, G): ");
                char tipPoruke = Console.ReadLine().ToUpper()[0];
                string poruka = "";
                if (tipPoruke == 'D' || tipPoruke == 'G') // ova dva tipa šalju poruku uz tip
                {
                    Console.Write("Podaci za slanje: ");
                    poruka = Console.ReadLine();
                }
                if (tipPoruke == 'F')
                {
                    Console.WriteLine("Unesi FEN primer ili pritisni Enter za defaultnu vrednost: ");
                    poruka = Console.ReadLine();
                    if (poruka.Length == 0)
                        poruka = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
                }

                // Kreiraj poruku u formatu Tip + Poruka
                string message = tipPoruke.ToString() + poruka;
                master.Send(Encoding.UTF8.GetBytes(message));

                ///Prihvati odgovor servera
                int bytesRecieved = master.Receive(buffer);
                byte[] pbd = new byte[bytesRecieved];
                Array.Copy(buffer, pbd, bytesRecieved);

                string odgovor = Encoding.UTF8.GetString(pbd);

                Console.WriteLine("Server je odgovorio sa: " + odgovor);
                // Ako je tip G podaci su sifrovani i moraju se desifrovati
                if (tipPoruke == 'G')
                    Console.WriteLine("Desifrovano: " + TripleDES.Decrypt(odgovor));
                Console.Write("Press any key to exit...");
                Console.ReadKey();
                master.Disconnect(false);
            }
            catch(SocketException e)
            {
                Console.WriteLine("Doslo je do greske sa soketom\nPoruka greske: " + e.Message);
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Doslo je do greske. \nPoruka greske: " + e.Message);
                Console.ReadKey();
            }
        }
    }
}
