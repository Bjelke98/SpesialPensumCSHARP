using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestAvAnnet;
public class Person {

    private static int IdCount = 0;

    public string FirstName { get; }
    public string LastName { get; }

    public int Id { get; }

    public int BirthYear { get; }

    // public DateOnly BirthDate { get; }
        
    private Person() {
        FirstName = "Not found";
        LastName = "Not found";
        BirthYear = -1;
        Id = ++IdCount;
    }

    public Person(string firstName, string lastName, int birthYear) : this(){
        FirstName = firstName;
        LastName = lastName;
        BirthYear = birthYear;
    }

    public Person(XElement person) : this() {
        XAttribute? firstName = person.Attribute("FirstName");
        XAttribute? lastName = person.Attribute("LastName");
        XAttribute? birthYear = person.Attribute("BirthYear");
        if (firstName != null) {
            FirstName = firstName.Value;
        }
        if (lastName != null) {
            LastName = lastName.Value;
        }
        if (birthYear != null) {
            BirthYear = int.Parse(birthYear.Value);
        }
    }

    public override string ToString() {
        return $"ID: {Id}, Name: {FirstName} {LastName}, Age: {DateTime.Now.Year-BirthYear}";
    }

    public XElement ToXML() {
        return new XElement("Person",
            new XAttribute("FirstName", FirstName),
            new XAttribute("LastName", LastName),
            new XAttribute("BirthYear", BirthYear));
    }
}