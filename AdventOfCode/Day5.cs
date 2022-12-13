using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {
    public class Day5 {

        private static readonly string[] moves = File.ReadAllLines(Statics.path + "Day5input.txt");
        private static readonly string[] initial = File.ReadAllLines(Statics.path + "Day5inputB.txt");

        private static readonly Stack<char>[] stacks = new Stack<char>[initial.Length];

        public static void Part1() {

            InitStacks();

            foreach (string move in moves) {
                /*
                 * Move ammount index 1
                 * from index 3
                 * to index 5
                 */
                string[] nums = move.Split(new char[] {' '});
                for (int i = 0; i < int.Parse(nums[1]); i++) {
                    stacks[int.Parse(nums[5])-1].Push(
                        stacks[int.Parse(nums[3])-1].Pop()
                    );
                }
            }

            PrintStacks();

        }

        public static void Part2() {

            InitStacks();

            foreach (string move in moves) {
                /*
                 * Move ammount index 1
                 * from index 3
                 * to index 5
                 */
                string[] nums = move.Split(new char[] { ' ' });
                Stack<char> temp = new Stack<char>();
                for (int i = 0; i < int.Parse(nums[1]); i++) {
                    temp.Push(
                        stacks[int.Parse(nums[3]) - 1].Pop()
                    );
                }
                for (int i = 0; i < int.Parse(nums[1]); i++) {
                    stacks[int.Parse(nums[5]) - 1].Push(
                        temp.Pop()
                    );
                }
            }

            PrintStacks();

        }

        private static void InitStacks() {
            for (int i = 0; i < initial.Length; i++) {
                stacks[i] = new Stack<char>(initial[i].ToCharArray());
            }
        }

        private static void PrintStacks() {
            for (int i = 0; i < stacks.Length; i++) {
                Console.Write("Stack " + (i + 1) + ":");
                foreach (char c in stacks[i].ToArray()) {
                    Console.Write(" " + c);
                }
                Console.WriteLine();
            }
        }

    }
}
