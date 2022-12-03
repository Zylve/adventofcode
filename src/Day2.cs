namespace net.zylve.aoc {
    public class Day2 {
        private const int ROCK = 1;
        private const int PAPER = 2;
        private const int SCISSORS = 3;

        private const int LOSS = 0;
        private const int DRAW = 3;
        private const int WIN = 6;

        public void Main1() {
            int score = 0;
            string input = File.ReadAllText("input/input2.txt");

            string[] lines = input.Split('\n');

            foreach(string line in lines) {
                switch(line) {
                    case "A X":
                        score += ROCK + DRAW;
                        break;

                    case "A Y":
                        score += PAPER + WIN;
                        break;

                    case "A Z":
                        score += SCISSORS + LOSS;
                        break;

                    case "B X":
                        score += ROCK + LOSS;
                        break;

                    case "B Y":
                        score += PAPER + DRAW;
                        break;

                    case "B Z":
                        score += SCISSORS + WIN;
                        break;

                    case "C X":
                        score += ROCK + WIN;
                        break;

                    case "C Y":
                        score += PAPER + LOSS;
                        break;

                    case "C Z":
                        score += SCISSORS + DRAW;
                        break;
                }
            }

            Console.WriteLine($"d2p1: {score}");
        }

        public void Main2() {
            int score = 0;
            string input = File.ReadAllText("input/input2.txt");

            string[] lines = input.Split('\n');

            foreach(string line in lines) {
                switch(line) {
                    case "A X":
                        score += LOSS + SCISSORS;
                        break;

                    case "A Y":
                        score += DRAW + ROCK;
                        break;

                    case "A Z":
                        score += WIN + PAPER;
                        break;

                    case "B X":
                        score += LOSS + ROCK;
                        break;

                    case "B Y":
                        score += DRAW + PAPER;
                        break;

                    case "B Z":
                        score += WIN + SCISSORS;
                        break;

                    case "C X":
                        score += LOSS + PAPER;
                        break;

                    case "C Y":
                        score += DRAW + SCISSORS;
                        break;

                    case "C Z":
                        score += WIN + ROCK;
                        break;
                }
            }

            Console.WriteLine($"d2p2: {score}");
        }
    }
}