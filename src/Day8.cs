namespace net.zylve.aoc {
    public class Day8 {
        private int[][] trees = Array.Empty<int[]>();

        private void parseInput() {
            string[] lines = File.ReadAllLines("input/input8.txt");

            trees = new int[lines.Length][];

            for(int i = 0; i < lines.Length; i++) {
                trees[i] = new int[lines[i].Length];

                for(int j = 0; j < trees[i].Length; j++) {
                    trees[i][j] = Convert.ToInt32(lines[i][j].ToString());
                }
            }
        }

        public void Main1() {
            parseInput();

            int visible = 0;

            for(int i = 0; i < trees.Length; i++) {
                for(int j = 0; j < trees[i].Length; j++) {
                    if(i == 0 || i == trees.Length - 1) {
                        visible++;
                        continue;
                    }

                    if(j == 0 || j == trees[i].Length - 1) {
                        visible++;
                        continue;
                    }

                    bool isVisible = true;

                    for(int k = 0; k < j; k++) {
                        if(trees[i][k] >= trees[i][j]) {
                            isVisible = false;
                            break;
                        }

                    }

                    if(!isVisible) {
                        isVisible = true;
                        for(int k = j + 1; k < trees[i].Length; k++) {
                            if(trees[i][k] >= trees[i][j]) {
                                isVisible = false;
                                break;
                            }

                        }
                    }

                    if(!isVisible) {
                        isVisible = true;
                        for(int k = 0; k < i; k++) {
                            if(trees[k][j] >= trees[i][j]) {
                                isVisible = false;
                                break;
                            }
                        }
                    }

                    if(!isVisible) {
                        isVisible = true;
                        for(int k = i + 1; k < trees[0].Length; k++) {
                            if(trees[k][j] >= trees[i][j]) {
                                isVisible = false;
                                break;
                            }
                        }
                    }

                    if(isVisible) {
                        visible++;
                    }
                }
            }

            Console.WriteLine(visible);
        }

        public void Main2() { }
    }
}