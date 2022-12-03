namespace net.zylve.aoc {
    public class Day3 {
        private string[] problemInput {
            get => File.ReadAllLines("input/input3.txt");
        }

        public void Main1() {
            int total = 0;

            foreach(string line in problemInput) {
                HashSet<char> left = line[..(line.Length / 2)].ToHashSet();
                HashSet<char> right = line[(line.Length / 2)..line.Length].ToHashSet();

                foreach(char c in left) {
                    if(right.Contains(c)) {
                        if(c > 'a') {
                            total += c - 'a' + 1;
                        } else {
                            total += c - 'A' + 27;
                        }
                    }
                }
            }

            Console.WriteLine($"d3p1: {total}");
        }

        public void Main2() {
            var array = problemInput.Chunk(3);

            int total = 0;

            foreach(var a in array) {
                HashSet<char> first = a[0].ToHashSet();
                HashSet<char> second = a[1].ToHashSet();
                HashSet<char> third = a[2].ToHashSet();

                foreach(char c in first) {
                    if(second.Contains(c) && third.Contains(c)) {
                        if(c > 'a') {
                            total += c - 'a' + 1;
                        } else {
                            total += c - 'A' + 27;
                        }
                    }
                }
            }

            Console.WriteLine($"d3p2: {total}");
        }
    }
}