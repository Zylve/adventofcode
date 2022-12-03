namespace net.zylve.aoc {
    public class Day1 {
        private IOrderedEnumerable<int>? calories {
            get => ReadInput().ToArray()
                    .GroupBy(x => x.id)
                    .Select(x => x.Sum(x => x.amount))
                    .OrderByDescending(x => x);
        }

        private static IEnumerable<(int id, int amount)> ReadInput() {
            int counter = 1;
            foreach(string line in File.ReadAllLines($"input/input1.txt")) {
                if(line?.Length == 0) {
                    counter++;
                } else {
                    yield return (counter, int.Parse(line!));
                }
            }
        }
        public void Main1() {
            Console.WriteLine($"Solution to problem one: {calories.Take(1).Sum()}");
        }

        public void Main2() {
            Console.WriteLine($"Solution to problem two: {calories.Take(3).Sum()}");
        }
    }
}