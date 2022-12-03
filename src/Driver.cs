namespace net.zylve.aoc {
    public static class Driver {
        private static void testAll() {
            new Day1().Main1();
            new Day1().Main2();

            new Day2().Main1();
            new Day2().Main2();

            new Day3().Main1();
            new Day3().Main2();
        }

        private static void TestSpecific(int type) {
            switch(type) {
                case 1:
                    new Day1().Main1();
                    new Day1().Main2();
                    break;

                case 2:
                    new Day2().Main1();
                    new Day2().Main2();
                    break;

                case 3:
                    new Day3().Main1();
                    new Day3().Main2();
                    break;
            }
        }

        public static void Main(string[] args) {
            if(args.Length > 0 && args[0] == "-a") {
                testAll();
                return;
            }

            if(args.Length > 0) {
                foreach(string str in args) {
                    if(str[..2] == "-n" && str.Length > 2) {
                        TestSpecific(Convert.ToInt32(str[2].ToString()));
                    }
                }
            }
        }
    }
}
