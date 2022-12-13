using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {
    public class Day6 {

        private static readonly string[] stream = File.ReadAllLines(Statics.path + "Day6input.txt");
        private static readonly char[] charStream = stream[0].ToCharArray();


        public static void Part1() {
            for (int i = 0; i < charStream.Length-3; i++) {
                if(AllUnique(
                    charStream[i],
                    charStream[i+1],
                    charStream[i+2],
                    charStream[i+3]
                )) {
                    Console.WriteLine(i + 4);
                    break;
                }
            }
        }

        public static void Part2() {
            for (int i = 0; i < charStream.Length-13; i++) {
                HashSet<char> message = new();
                for (int j = 0; j < 14; j++) {
                    message.Add(charStream[i + j]);
                }
                if(message.Count == 14) {
                    Console.WriteLine(i + 14);
                    break;
                }
            }
        }

        //private static bool DistinctCharacters(List<char> list) {
        //    HashSet<char> set = new(list);
        //    return list.Count == set.Count;
        //}

        private static bool AllUnique(char a, char b, char c, char d) {
            if (a == b || a == c || a == d || b == c || b == d || c == d) return false;
            return true;
        }

    }
}
