using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestAvAnnet {
    public class LinqAndXML {

        private static readonly List<Person> personList = new() {
            new Person ("Krister", "Iversen", 1998),
            new Person ("Henrik", "Lindam", 1998),
            new Person ("Adrian", "Dahl", 2000),
            new Person ("Olav", "Lille-Østerholt", 2001),
            new Person ("John Ivar", "Lilleøren Hagen", 1901),
            new Person ("Herman", "Simonsen", 2001),
            new Person ("Nils Ole", "Lensebakken", 1997)
        };

        public static void Run() {

            IEnumerable<Person> personListFilter = personList
                .Where(p => p.BirthYear < 2000)
                .OrderBy(p => p.FirstName);

            // Utskrift
            Spacer("Personer født før år 2000");
            PrintAll(personListFilter);

            personListFilter = personList
                .Where(p => p.BirthYear >= 2000)
                .OrderBy(p => p.FirstName);

            // Utskrift
            Spacer("Resten");
            PrintAll(personListFilter);


            // XML
            XElement personXML = new("People", personList.Select(p => p.ToXML()));
            personXML.Save(Statics.path + "People.xml");

            XElement data = XElement.Load(Statics.path + "People.xml");
            List<Person> readPeople = new(data.Elements().Select(p => new Person(p)));

            // Utskrift
            Spacer("Hentet fra XML dokument");
            PrintAll(readPeople);

            // Lagre ny person
            data.Add(new Person("Arne", "Bernt Egil", 1990).ToXML());
            data.Save(Statics.path + "People.xml");

            readPeople = new(data.Elements().Select(p => new Person(p)));

            // Utskrift med ny person
            Spacer("Liste med ny person");
            PrintAll(readPeople);

            Spacer();
        }
        private static void Spacer() {
            Console.WriteLine();
            Console.WriteLine("--- --- ---");
            Console.WriteLine();
        }
        private static void Spacer(string output) {
            Spacer();
            Console.WriteLine(output);
            Console.WriteLine();
        }

        private static void PrintAll<T>(IEnumerable<T> list) {
            foreach (T i in list) Console.WriteLine(i);
        }

    }
}
