using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {
    public class Day8 {
        private static readonly string[] trees = File.ReadAllLines(Statics.path + "Day8input.txt");

        private static readonly int mapSize = 99;

        private static readonly int[,] treeMap = makeTree();

        public static void Part1() { 

            int sumVisible = 0;

            for (int i = 1; i < mapSize - 1; i++) {

                for (int j = 1; j < mapSize - 1; j++) {

                    if (isVisible(i, j)) sumVisible++;

                }

            }

            Console.WriteLine(sumVisible+mapSize*4-4);

        }

        public static void Part2() {

            int bestViewScore = 0;

            for (int i = 1; i < mapSize - 1; i++) {

                for (int j = 1; j < mapSize - 1; j++) {

                    bestViewScore = Math.Max(getViewScore(i, j), bestViewScore);

                }

            }

            Console.WriteLine(bestViewScore);

        }

        private static int getViewScore(int row, int col) {
            int up = 0;
            int down = 0;
            int left = 0;
            int right = 0;

            int val = treeMap[row, col];

            // Up
            for (int i = row - 1; i >= 0; i--) {
                up++;
                if (val <= treeMap[i, col]) {
                    break;
                }
            }

            // Left
            for (int i = col - 1; i >= 0; i--) {
                left++;
                if (val <= treeMap[row, i]) {
                    break;
                }
            }

            // Down
            for (int i = row + 1; i < mapSize; i++) {
                down++;
                if (val <= treeMap[i, col]) {
                    break;
                }
            }

            // Right
            for (int i = col + 1; i < mapSize; i++) {
                right++;
                if (val <= treeMap[row, i]) {
                    break;
                }
            }

            return up*down*left*right;
        }

        private static int[,] makeTree() {
            int[,] treeMap = new int[mapSize, mapSize];
            for (int i = 0; i < 99; i++) {
                char[] row = trees[i].ToCharArray();
                for (int j = 0; j < mapSize; j++) {
                    treeMap[i, j] = row[j] - 48;
                }
            }
            return treeMap;
        }

        private static bool isVisible(int row, int col) {
            bool up = true;
            bool down = true;
            bool left = true;
            bool right = true;

            int val = treeMap[row, col];

            // Up
            for (int i = row-1; i >= 0; i--) {
                if (val <= treeMap[i, col]) {
                    up = false;
                    break;
                }
            }

            // Left
            for (int i = col - 1; i >= 0; i--) {
                if (val <= treeMap[row, i]) {
                    left = false;
                    break;
                }
            }

            // Down
            for (int i = row + 1; i < mapSize; i++) {
                if (val <= treeMap[i, col]) {
                    down = false;
                    break;
                }
            }

            // Down
            for (int i = col + 1; i < mapSize; i++) {
                if (val <= treeMap[row, i]) {
                    right = false;
                    break;
                }
            }

            return (up || down || left || right);

        }
    }
}
