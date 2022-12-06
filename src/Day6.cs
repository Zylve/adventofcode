namespace net.zylve.aoc {
    public class Day6 {
        public void Main1() {
            string input = File.ReadAllText("input/input6.txt");

            for(int i = 3; i < input.Length - 3; i++) {
                var letters = input.Skip(i).Take(4);

                if(letters.ToHashSet().Count == 4) {
                    Console.WriteLine($"d6p1: {i + 4}");
                    break;
                }
            }
        }

        public void Main2() {
            string input = File.ReadAllText("input/input6.txt");

            for(int i = 14; i < input.Length; i++) {
                var letters = input.Skip(i).Take(14);

                if(letters.ToHashSet().Count == 14) {
                    Console.WriteLine($"d6p2: {i + 14}");
                    break;
                }
            }
        }
    }
}