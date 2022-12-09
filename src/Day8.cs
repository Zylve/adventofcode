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

            Console.WriteLine($"d8p1: {visible}");
        }

        public void Main2() {
            parseInput();

            int maxScenicScore = 1;

            for(int i = 0; i < trees.Length; i++) {
                for(int j = 0; j < trees[i].Length; j++) {
                    int scenicScore = 1;

                    int up = 0;
                    int down = 0;
                    int left = 0;
                    int right = 0;

                    for(int k = j - 1; k >= 0; k--) {
                        left++;

                        if(trees[i][j] <= trees[i][k]) {
                            break;
                        }

                    }

                    for(int k = j + 1; k < trees[i].Length; k++) {
                        right++;

                        if(trees[i][j] <= trees[i][k]) {
                            break;
                        }
                    }

                    for(int k = i - 1; k >= 0; k--) {
                        up++;

                        if(trees[i][j] <= trees[k][j]) {
                            break;
                        }
                    }

                    for(int k = i + 1; k < trees.Length; k++) {
                        down++;

                        if(trees[i][j] <= trees[k][j]) {
                            break;
                        }
                    }

                    scenicScore = up * down * left * right;
                    maxScenicScore = Math.Max(maxScenicScore, scenicScore);
                }
            }

            Console.WriteLine($"d8p2: {maxScenicScore}");
        }
    }
}