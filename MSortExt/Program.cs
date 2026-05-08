using System.Diagnostics;
using System.Text;

namespace MSortExt
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int records = 10000;
            string inputFile = "test.txt";
            string outputFile = "output.txt";

            Util.GetRandomFile(inputFile, records);

            var timer = new Stopwatch();
            timer.Start();

            int count = Util.GetLineCount(inputFile);
            if (count < 1000)
            {
                Util.InternalSort(inputFile, outputFile);
            }
            else
            {
                Util.GetSortedRuns(inputFile);
                Util.MergeSort(outputFile);
                Util.DeleteRuns();
            }

            timer.Stop();

            Console.WriteLine(Util.IsSorted(outputFile));

            TimeSpan myTime = timer.Elapsed;
            Console.Write(myTime.TotalMilliseconds);
            Console.WriteLine(" ms");
        }

 
    }
}
