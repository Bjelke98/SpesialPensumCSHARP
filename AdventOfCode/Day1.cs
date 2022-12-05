using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {
    public class Day1 {

        private static readonly string[] calories = System.IO.File.ReadAllLines(Statics.path+"Day1input.txt");
        public static void Part1() {
            int topCal = 0;
            int currCal = 0;

            foreach (string calorie in calories) {
                if (calorie.Length == 0) {
                    if (currCal > topCal) {
                        topCal = currCal;
                    }
                    currCal = 0;
                    continue;
                }
                bool ok = int.TryParse(calorie, out int cal);
                if (!ok) {
                    Console.WriteLine("Error in parsing");
                    break;
                }
                currCal += cal;
            }

            Console.WriteLine("Top cal: "+topCal);
        }

        public static void Part2() {
            int[] top3 = new int[4];
            int currCal = 0;

            foreach (string calorie in calories) {
                if (calorie.Length == 0) {
                    top3[0] = currCal;
                    Array.Sort(top3);
                    currCal = 0;
                    continue;
                }
                bool ok = int.TryParse(calorie, out int cal);
                if (!ok) {
                    Console.WriteLine("Error in parsing");
                    break;
                }
                currCal += cal;
            }

            Console.WriteLine("Top1: " + top3[3] +", Top2: "+ top3[2] + ", Top3: "+ top3[1] + ", sum = "+(top3[3] + top3[2] + top3[1]));
        }

    }
}
