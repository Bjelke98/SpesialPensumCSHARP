using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {
    public class Day4 {

        private static readonly string[] pairs = File.ReadAllLines(Statics.path + "Day4input.txt");

        public static void Part1() {

            int containsSum = 0;

            foreach(string pair in pairs) {
                string[] single = pair.Split(new char[] { '-', ',' });
                if (FullyContains(
                    int.Parse(single[0]),
                    int.Parse(single[1]),
                    int.Parse(single[2]),
                    int.Parse(single[3])
                )) containsSum++;
            }
            
            Console.WriteLine(containsSum);
        }

        public static void Part2() {
            int overlapSum = 0;

            foreach (string pair in pairs) {
                string[] single = pair.Split(new char[] { '-', ',' });
                if (Overlaps(
                    int.Parse(single[0]),
                    int.Parse(single[1]),
                    int.Parse(single[2]),
                    int.Parse(single[3])
                )) overlapSum++;
            }

            Console.WriteLine(overlapSum);
        }

        private static bool FullyContains(int a, int b, int c, int d) =>
            (a >= c && b <= d) ||
            (c >= a && d <= b);

        private static bool Overlaps(int a, int b, int c, int d) =>
            (a <= d && d <= b) ||
            (a <= d && d <= b) ||
            (c <= a && a <= c) ||
            (c <= b && b <= d);

    }
}
