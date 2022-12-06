namespace net.zylve.aoc {
    public class Day5 {
        private string[] input = Array.Empty<string>();
        private Stack<char>[] stacks = Array.Empty<Stack<char>>();
        private int stackNumberLine = 0;
        private void readInput() {
            input = File.ReadAllLines("input/input5.txt");
        }

        private void parseStacks() {
            for(int i = 0; i < input.Length; i++) {
                if(input[i][1] == '1') {
                    stackNumberLine = i;
                    stacks = new Stack<char>[Convert.ToInt32(input[i][^2].ToString())];

                    for(int j = 0; j < stacks.Length; j++) {
                        stacks[j] = new Stack<char>();
                    }

                    break;
                }
            }

            foreach(string str in input.Take(8).Reverse()) {
                var crates = str.Chunk(4);

                for(int i = 0; i < crates.Count(); i++) {
                    if(crates.ElementAt(i)[0] == '[') {
                        stacks[i].Push(crates.ElementAt(i)[1]);
                    }
                }
            }
        }

        private (int, int, int)[] parseInstructions() {
            (int, int, int)[] instructions = new (int, int, int)[input.Length - stackNumberLine - 2];
            foreach(string str in input.Skip(stackNumberLine + 2)) {

            }

            for(int i = 0; i < instructions.Length; i++) {
                string instruction = input.ElementAt(i + stackNumberLine + 2);
                string[] subSet = instruction.Split(' ');

                int numberOfCrates = Convert.ToInt32(subSet[1]);
                int inStack = Convert.ToInt32(subSet[3]);
                int outStack = Convert.ToInt32(subSet[5]);

                instructions[i] = (numberOfCrates, inStack, outStack);
            }

            return instructions;
        }

        private static string collectCrates(Stack<char>[] stacks) {
            string crates = "";

            foreach(Stack<char> stack in stacks) {
                crates += stack.Pop();
            }

            return crates;
        }

        public void Main1() {
            readInput();
            parseStacks();

            (int, int, int)[] instructions = parseInstructions();

            for(int i = 0; i < instructions.Length; i++) {
                (int number, int inStack, int outStack) = instructions[i];

                for(int j = 0; j < number; j++) {
                    stacks[outStack - 1].Push(stacks[inStack - 1].Pop());
                }
            }

            string crates = collectCrates(this.stacks);

            Console.WriteLine($"d5p1: {crates}");
        }

        public void Main2() {
            readInput();
            parseStacks();

            (int, int, int)[] instructions = parseInstructions();

            for(int i = 0; i < instructions.Length; i++) {
                (int number, int inStack, int outStack) = instructions[i];

                string cratesTemp = "";
                for(int j = 0; j < number; j++) {
                    cratesTemp += stacks[inStack - 1].Pop();
                }

                foreach(char c in cratesTemp.Reverse()) {
                    stacks[outStack - 1].Push(c);
                }
            }

            string crates = collectCrates(this.stacks);

            Console.WriteLine($"d5p2: {crates}");
        }
    }
}