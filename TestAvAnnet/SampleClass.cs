using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAvAnnet;

public class SampleClass {

    private string name = "";

    public string Name { 
        get { return name; }
        set { name = value+" - "; }
    }

    public void Print() {
        Console.WriteLine(name);
    }

}

public interface ISample {
    void Print2x();

    // Med Default
    void Print3x() {
        Console.WriteLine(1);
        Console.WriteLine(2);
        Console.WriteLine(3);
    }

    // 1 linje metode
    static string Hello { get; set; } = "Hei";
    void SiHei() => Console.WriteLine(Hello);
}

public class ExtendSampleClass : SampleClass, ISample {
    public void Print2x() {
        Print();
        Print();
    }
}



