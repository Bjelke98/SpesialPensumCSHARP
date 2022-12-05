using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {
    internal class Day2 {
        
        private static readonly string[] rounds = System.IO.File.ReadAllLines(Statics.path+"Day2input.txt");
        public static void Part1() {
            int sumRounds = 0;
            foreach (string round in rounds) {
                sumRounds += GetScore(round);
            }
            Console.WriteLine(sumRounds);
        }
        public static void Part2() {
            int sumRounds = 0;
            foreach (string round in rounds) {
                sumRounds += GetScorePart2(round);
            }
            Console.WriteLine(sumRounds);
        }

        private static int GetScorePart2(string round) {
            char[] player = round.ToCharArray();
            return player[2] switch {
                'X' => GetMoveScore(GetLoosingMove(player[0])),// Lose
                'Y' => GetMoveScore(player[0]) + 3,// Draw
                _ => GetMoveScore(GetWinningMove(player[0])) + 6,// Win
            };
        }

        private static char GetWinningMove(char move) {
            return move switch {
                'A' => 'B',
                'B' => 'C',
                _ => 'A',
            };
        }
        private static char GetLoosingMove(char move) {
            return move switch {
                'A' => 'C',
                'B' => 'A',
                _ => 'B',
            };
        }

        private static int GetScore(string round) {
            char[] player = round.ToCharArray();
            int sum = GetMoveScore(player[2]);
            int p2sum = GetMoveScore(player[0]);
            return sum+GetRoundScore(sum, p2sum);
        }

        private static int GetRoundScore(int p1, int p2) {
            if (p1 == p2) return 3; // Draw
            if (p1 - 1 == p2 || p1 + 2 == p2) return 6; // Win
            return 0;
        }

        private static int GetMoveScore(char move) {
            return move switch {
                'A' or 'X' => 1, // Rock
                'B' or 'Y' => 2, // Paper
                'C' or 'Z' => 3, // Scissors
                // ???
                _ => 0,
            };
        }

    }
}
