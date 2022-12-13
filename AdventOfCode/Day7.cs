using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {
    interface HasSize {
        int getSize();
        Dictionary<string, HasSize> getContents();
        bool isDir();
    }
    class AdFile : HasSize {
        private int size;
        public AdFile(int _size) {
            size = _size;
        }

        public Dictionary<string, HasSize> getContents() {
            throw new NotImplementedException();
        }

        public int getSize() {
            return size;
        }

        public bool isDir() {
            return false;
        }
    }
    class AdDirectory : HasSize {
        private Dictionary<string, HasSize> contents = new();

        public Dictionary<string, HasSize> getContents() {
            return contents;
        }

        public int getSize() {
            int sum = 0;
            foreach (var item in contents) sum += item.Value.getSize();
            return sum;
        }
        public bool isDir() {
            return true;
        }
    }
    public class Day7 {

        private static readonly string[] console = File.ReadAllLines(Statics.path + "Day7input.txt");

        private static int discSpace = 70_000_000;
        private static int discSpaceUsed = 0;
        private static int discSpaceNeeded = 30_000_000;
        private static int discTarget = 0;

        private static int bestCandidate = discSpace;

        public static void Part1() {
            Stack<AdDirectory> parentStack = new();
            AdDirectory root = new AdDirectory();
            
            parentStack.Push(root);

            // index 0: $ cd /
            for (int i = 1; i < console.Length; i++) {
                string[] command = console[i].Split(" ");

                switch (command[0]) {
                    case "$":
                        if (command[1] == "cd") {
                            if (command[2] == "..") {
                                parentStack.Pop();
                            } else {
                                HasSize nextDir;
                                if (parentStack.Peek().getContents().TryGetValue(command[2], out nextDir))
                                    parentStack.Push((AdDirectory)nextDir);
                            }
                        }
                        break;
                    case "dir":
                        parentStack.Peek().getContents().Add(command[1], new AdDirectory());
                        break;
                    default:
                        parentStack.Peek().getContents().Add(command[1], new AdFile(int.Parse(command[0])));
                        break;
                }
            }

            discSpaceUsed = root.getSize();

            int currentSpace = discSpace - discSpaceUsed;

            discTarget = discSpaceNeeded - currentSpace;

            printTree("/", root, "");

            Console.WriteLine();

            Console.WriteLine("Part1");
            Console.WriteLine(treeSum);

            Console.WriteLine("---");

            Console.WriteLine("Part2");
            Console.WriteLine(bestCandidate);
        }

        // All folders less than or equals to 100 000
        private static int treeSum = 0;

        private static void printTree(string name, AdDirectory dir, string space) {
            Console.WriteLine(space + name + ": " + dir.getSize());
            space += "   ";
            if (dir.getSize() <= 100_000) {
                treeSum += dir.getSize();
            }
            
            // Part 2

            if(dir.getSize()<bestCandidate && dir.getSize() >= discTarget) {
                bestCandidate = dir.getSize();
            }

            // Part 2 end

            Dictionary<string, HasSize> contents = dir.getContents();
            foreach(var item in contents) {
                if (item.Value.isDir()) {
                    printTree(item.Key, (AdDirectory)item.Value, space);
                } else {
                    Console.WriteLine(space + item.Key + "(f): " + item.Value.getSize());
                }
            }
        }
    }
}
