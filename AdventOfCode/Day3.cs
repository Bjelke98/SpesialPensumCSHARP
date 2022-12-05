using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {
    public class Day3 {
        private static readonly string[] rucksack = File.ReadAllLines(Statics.path + "Day3input.txt");
        public static void Part1() {
            char[] common = new char[rucksack.Length];
            int commonPrioritySum = 0;

            for (int i = 0; i < rucksack.Length; i++) common[i] = FindCommonChar(rucksack[i]);

            foreach(char c in common) commonPrioritySum += CharValue(c);

            Console.WriteLine(commonPrioritySum);
        }

        public static void Part2(){
            int sum = 0;
            for(int i = 0; i<rucksack.Length;i+=3) {
                int[] prioCount = new int[52];
                for(int j = 0; j<3; j++) {
                    HashSet<char> both = new(rucksack[i + j].ToCharArray());
                    foreach (char c in both) prioCount[CharValue(c) - 1]++;
                }
                for(int j = 0; j<prioCount.Length; j++) {
                    if (prioCount[j] == 3) {
                        sum += j + 1;
                        break;
                    }
                }
            }
            Console.WriteLine(sum);
        }

        private static char FindCommonChar(string sack) {
            char[] both = sack.ToCharArray();
            char[] firstHalf = new char[both.Length / 2];
            for (int i = 0; i < both.Length / 2; i++) firstHalf[i] = both[i];
            for (int i = both.Length / 2; i < both.Length; i++) {
                if (firstHalf.Contains(both[i])) return both[i];
            }
            throw new Exception("No common chars in sack. B - " + both.Length + " H - " + firstHalf.Length);
        }

        private static int CharValue(char c) {
            return c < 97 ? c - 38 : c - 96;
        }
    }
}
