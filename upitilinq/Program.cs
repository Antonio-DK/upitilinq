using System;
using System.Collections.Generic;
using System.Linq;

namespace upitilinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Knjiga> knjige = new List<Knjiga>
            {
                new Knjiga {Naslov = "1984", Autor = "George Orwell", Godina = 1960},
                new Knjiga {Naslov = "Ubiti pticu rugalicu", Autor = "Harper Lee", Godina = 1960},
                new Knjiga {Naslov = "Lokalna pekara slatko slano", Autor = "Luka Akmacic", Godina = 1520},
                new Knjiga {Naslov = "Tajne grade racunala", Autor = "Luka Akmacic", Godina = 1520}
            };

            Console.WriteLine("Odaberite kriterij pretrage:");
            Console.WriteLine("1. Naslov");
            Console.WriteLine("2. Autor");
            Console.WriteLine("3. Godina izdanja");

            int izbor = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite vrijednost za pretragu: ");
            string unos = Console.ReadLine();

            IEnumerable<Knjiga> rezultati = null;

            switch (izbor)
            {
                case 1:
                    rezultati = knjige.Where(k => k.Naslov.ToLower().Contains(unos.ToLower()));
                    break;
                case 2:
                    rezultati = knjige.Where(k => k.Autor.ToLower().Contains(unos.ToLower()));
                    break;
                case 3:
                    if (int.TryParse(unos, out int godina))
                    {
                        rezultati = knjige.Where(k => k.Godina == godina);
                    }
                    else
                    {
                        Console.WriteLine("Unesena godina mora biti broj.");
                    }
                    break;
                default:
                    Console.WriteLine("Nevažeći izbor.");
                    break;
            }

            if (rezultati != null && rezultati.Any())
            {
                Console.WriteLine("\nRezultati pretrage:");
                foreach (var knjiga in rezultati)
                {
                    Console.WriteLine($"Naslov: {knjiga.Naslov}, Autor: {knjiga.Autor}, Godina: {knjiga.Godina}");
                }
            }
            else
            {
                Console.WriteLine("\nNema rezultata za uneseni kriterij.");
            }

            Console.WriteLine("\nPritisnite bilo koju tipku za izlaz...");
            Console.ReadKey();
        }
    }

    class Knjiga
    {
        public string Naslov { get; set; }
        public string Autor { get; set; }
        public int Godina { get; set; }
    }
}