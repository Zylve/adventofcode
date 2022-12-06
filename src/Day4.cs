namespace net.zylve.aoc {
    public class Day4 {
        public void Main1() {
            int pairs = 0;
            var input = File.ReadAllLines("input/input4.txt");

            foreach(string s in input) {
                int i = Convert.ToInt32(s.Split(',')[0].Split('-')[0]);
                int j = Convert.ToInt32(s.Split(',')[0].Split('-')[1]);

                int k = Convert.ToInt32(s.Split(',')[1].Split('-')[0]);
                int l = Convert.ToInt32(s.Split(',')[1].Split('-')[1]);

                if((i <= k && j >= l) || (i >= k && j <= l)) {
                    pairs++;
                }
            }

            Console.WriteLine($"d4p1: {pairs}");
        }

        public void Main2() {
            int overlaps = 0;
            string[] input = File.ReadAllLines("input/input4.txt");

            foreach(string line in input) {
                string[] set = line.Split(',');
                string[] leftRange = set[0].Split('-');
                string[] rightRange = set[1].Split('-');

                int leftLowerBound = Convert.ToInt32(leftRange[0]);
                int leftUpperBound = Convert.ToInt32(leftRange[1]);
                int rightLowerBound = Convert.ToInt32(rightRange[0]);
                int rightUpperBound = Convert.ToInt32(rightRange[1]);

                if(leftLowerBound.IsBetween(rightLowerBound, rightUpperBound)
                    || leftUpperBound.IsBetween(rightLowerBound, rightUpperBound)
                    || rightLowerBound.IsBetween(leftLowerBound, leftUpperBound)
                    || rightUpperBound.IsBetween(leftLowerBound, leftUpperBound)) {

                    overlaps++;
                }
            }

            Console.WriteLine($"d4p2: {overlaps}");
        }
    }

    public static class Extensions {
        public static bool IsBetween(this int i, int x, int y) {
            return i >= x && i <= y;
        }
    }
}