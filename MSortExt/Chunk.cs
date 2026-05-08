
namespace MSortExt
{
    public class Chunk
    {
        private int MaxQueueSize = 20;

        public StreamReader Reader;
        public Queue<string> Queue;


        public Chunk(string fileName)
        {
            Reader = new StreamReader(fileName);
            Queue = new Queue<string>();
        }


        public void Load()
        {
            for (int i = 0; i < MaxQueueSize; i++)
            {
                if (Reader.Peek() < 0)
                    break;
                Queue.Enqueue(Reader.ReadLine());
            }
        }

        public string Top()
        {
            return Queue.Peek();
        }

        public void Remove()
        {
            if (Queue.Count > 0)
            {
                Queue.Dequeue();
            }
            if (Queue.Count == 0)
            {
                Load();
            }
        }

        public bool IsEmpty()
        {
            return (Queue.Count == 0);
        }

        public void Clear()
        {
            Reader.Close();
            Queue.Clear();
        }

    }
}
