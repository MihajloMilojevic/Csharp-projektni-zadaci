using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sever
{
    class FEN
    {
        public static string Prikaz(string ulaz)
        {
            if (ulaz.Length == 0) return "Neispravan format.";
            string[] delovi = ulaz.Split(' ');
            if (delovi.Length != 6) return "Neispravan format";
            string tabla = PrikazTable(delovi[0]);
            string naPotezu = PrikazNaPotezu(delovi[1]);
            string rokade = PrikazRokada(delovi[2]);
            string elPassant = PrikazElPassant(delovi[3]);
            string poluPotezi = PrikazPoluPoteza(delovi[4]);
            string potezi = PrikazPoteza(delovi[5]);
            return "Sahovska tabla:\n\n" + tabla + "\n\n" + naPotezu + "\n\n" + rokade + "\n\n" + elPassant + "\n" + poluPotezi + "\n" + potezi + "\n\n";
        }
        public static string PrikazTable(string ulaz)
        {
            string[] redovi = ulaz.Split('/');
            if (redovi.Length != 8) return "Neispravan format table";
            string tabla = "";
            foreach(string red in redovi)
            {
                foreach(char znak in red)
                {
                    if (Char.IsDigit(znak))
                        tabla += RepeatString(" ", int.Parse(znak.ToString()));
                    else
                        tabla += znak;
                }
                tabla += "\n";
            }
            return tabla;
        }
        public static string PrikazNaPotezu(string ulaz)
        {
            char znak = ulaz.ToUpper()[0];
            if (znak == 'W') return "Na potezu: beli";
            if (znak == 'B') return "Na potezu: crni";
            return "Neispravan format";
        }
        public static string PrikazRokada(string ulaz)
        {
            if (ulaz.ToUpper().Replace("-", "").Replace("K", "").Replace("Q", "").Length != 0) return "Neispravan format";
            if (ulaz == "-") return "Mogucnost rokade:\n nema";
            string izlaz = "Mogucnost rokade:\n";
            foreach(char z in ulaz)
            {
                izlaz += ((Char.IsUpper(z) ? "beli, " : "crni, ") + (z.ToString().ToUpper() == "K" ? "kraljeva " : "damina ") + "strana\n");
            }
            return izlaz;
        }
        public static string PrikazElPassant(string ulaz)
        {
            return "El passant: " + (ulaz == "-" ? "nema" : ulaz);
        }
        public static string PrikazPoluPoteza(string ulaz)
        {
            if (int.TryParse(ulaz, out _))
                return "Broj polupoteza: " + ulaz;
            return "Neispravan format polupoteza";
        }
        public static string PrikazPoteza(string ulaz)
        {
            if (int.TryParse(ulaz, out _))
                return "Broj poteza: " + ulaz;
            return "Neispravan format poteza";
        }
        private static string RepeatString(string s, int num)
        {
            string izlaz = "";
            for (int i = 0; i < num; i++)
                izlaz += s;
            return izlaz;
        }
    } 
}
