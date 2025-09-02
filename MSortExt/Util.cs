using System.Text;

namespace MSortExt
{
    public static class Util
    {
        private static int MaxRunSize = 1000;

        private static Random random = new Random();
        public static string GetRandomString(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[random.Next(chars.Length)]);
            }
            return sb.ToString();
        }

        public static void GetRandomFile(string outputFile, int length)
        {
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                for (int i = 0; i < length; i++)
                {
                    // Get random length strings.
                    int n = random.Next(10) + 1;
                    string a = GetRandomString(n);
                    writer.WriteLine(a);
                }
                writer.Close();
            }
        }

        public static void MergeSort(string outputFile)
        {
            string myPath = Directory.GetCurrentDirectory();
            string[] paths = Directory.GetFiles(myPath, "RUN*.txt");
            List<Chunk> chunks = new List<Chunk>();

            // initialize
            if (paths.Length > 0)
            {
                for (int i = 0; i < paths.Length; i++)
                {
                    var chunk = new Chunk(paths[i]);
                    chunks.Add(chunk);
                    chunk.Load();
                }
            }

            // Get smallest value.
            StreamWriter sw = new StreamWriter(outputFile);
            string minValue;
            Chunk minChunk = null;
            bool done = false;

            while (!done)
            {
                // Find the chunk with the smallest value.
                minValue = String.Empty;
                minChunk = null;
                foreach (var chunk in chunks)
                {
                    if (minChunk == null || String.Compare(chunk.Top(), minValue, StringComparison.CurrentCulture) < 0)
                    {
                        minChunk = chunk;
                        minValue = chunk.Top();
                    }
                }

                if (minChunk == null)
                {
                    // All chunks are empty.
                    done = true;
                    break;
                }

                sw.WriteLine(minValue);
                minChunk.Remove();
                if (minChunk.IsEmpty())
                {
                    chunks.Remove(minChunk);
                    minChunk.Clear();
                    minChunk = null;
                }
            }

            sw.Close();
        }

        public static void GetSortedRuns(string inputFile)
        {
            int runCount = 0;
            using (StreamReader reader = new StreamReader(inputFile))
            {
                List<string> chunk = new List<string>();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    chunk.Add(line);
                    if (chunk.Count > MaxRunSize)
                    {
                        // Output Run File.
                        chunk.Sort();
                        runCount++;
                        File.WriteAllLines(Path.Combine($"RUN{runCount}.txt"), chunk);
                        chunk.Clear();
                    }
                }

                if (chunk.Any())
                {
                    // Remainder
                    chunk.Sort();
                    runCount++;
                    File.WriteAllLines(Path.Combine($"RUN{runCount}.txt"), chunk);
                }
            }
        }

        public static void InternalSort(string inputFile, string outputFile)
        {
            List<string> list = new List<string>();
            using (StreamReader reader = new StreamReader(inputFile))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                        break;
                    list.Add(line);
                }
            }

            list.Sort();
            File.WriteAllLines(outputFile, list);
            list.Clear();
        }

        public static int GetLineCount(string inputFile)
        {
            int count = 0;
            using (StreamReader reader = new StreamReader(inputFile))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                        break;
                    count++;
                }
            }

            return count;
        }

        public static bool IsSorted(string inputFile)
        {
            using (StreamReader reader = new StreamReader(inputFile))
            {
                string line;
                string last = String.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    if (String.Compare(last, line, StringComparison.CurrentCulture) > 0)
                    {
                        return false;
                    }

                    last = line;
                }

            }

            return true;
        }

        public static void DeleteRuns()
        {
            string myPath = Directory.GetCurrentDirectory();
            string[] paths = Directory.GetFiles(myPath, "RUN*.txt");

            foreach (string path in paths)
            {
                File.Delete(path);
            }
        }


    }
}
