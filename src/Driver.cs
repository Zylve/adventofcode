namespace net.zylve.aoc {
    public static class Driver {
        private static void testAll() {
            new Day1().Main1();
            new Day1().Main2();

            new Day2().Main1();
            new Day2().Main2();
        }

        public static void Main(string[] args) {
            // new Day3().Main1();
            new Day3().Main2();

            if(args.Length > 0 && args[0] == "-a") {
                testAll();
                return;
            }
        }
    }
}