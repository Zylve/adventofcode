namespace net.zylve.aoc {

    internal class DirectoryObject {
        public string Path = "";
        public int Size = 0;

        public DirectoryObject(string path) {
            this.Path = path;
        }
    }

    public class Day7 {
        private string[] input = Array.Empty<string>();
        private string path = "/";
        private List<DirectoryObject> directories = new List<DirectoryObject>();

        public void Main1() {
            input = File.ReadAllLines("input/input7.txt");

            directories.Add(new DirectoryObject("/"));

            for(int i = 1; i < input.Length; i++) {
                if(input[i] == "$ ls") {
                    continue;
                }

                if(input[i] == "$ cd ..") {
                    path = path[..^1][..(path.LastIndexOf("/", path.Length - 2) + 1)];
                } else if(input[i].StartsWith("$ cd")) {
                    string dir = input[i].Split(' ')[2];
                    path += dir + "/";
                    directories.Add(new DirectoryObject(path));
                } else if(!input[i].StartsWith("dir")) {
                    DirectoryObject dir = directories.Find(x => x.Path == path)!;
                    directories.Where(x => path.StartsWith(x.Path)).ToList().ForEach(x => x.Size += Convert.ToInt32(input[i].Split(' ')[0]));
                }
            }

            Console.WriteLine($"d7p1: {directories.Select(x => x.Size).Where(x => x <= 100000).Sum()}");
        }

        public void Main2() {
            const int totalSpace = 70000000;
            const int freeSpaceRequired = 30000000;
            int currentFreeSpace = 0;

            input = File.ReadAllLines("input/input7.txt");
            directories.Add(new DirectoryObject("/"));

            for(int i = 1; i < input.Length; i++) {
                if(input[i] == "$ ls") {
                    continue;
                }

                if(input[i] == "$ cd ..") {
                    path = path[..^1][..(path.LastIndexOf("/", path.Length - 2) + 1)];
                } else if(input[i].StartsWith("$ cd")) {
                    string dir = input[i].Split(' ')[2];
                    path += dir + "/";
                    directories.Add(new DirectoryObject(path));
                } else if(!input[i].StartsWith("dir")) {
                    DirectoryObject dir = directories.Find(x => x.Path == path)!;
                    directories.Where(x => path.StartsWith(x.Path)).ToList().ForEach(x => x.Size += Convert.ToInt32(input[i].Split(' ')[0]));
                }
            }

            currentFreeSpace = totalSpace - directories.Find(x => x.Path == "/")!.Size;

            Console.WriteLine($"d7p2: {directories.Where(x => x.Size + currentFreeSpace >= freeSpaceRequired).OrderBy(x => x.Size).First().Size}");
        }
    }
}