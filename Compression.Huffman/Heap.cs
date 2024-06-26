using System.Text;

namespace Compression.Huffman;

public class Heap : IHeap
{ 
    class Node
    {
        public char Character { get; set; }
        public int Frequency { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public Node()
        {
        }

        // used to create the forr
        public Node(char character, int frequency)
        {
            Character = character;
            Frequency = frequency;
        }

        /// This is the Heap Node        
        public Node(char character,
            int frequency,
            Node? leftNode = null,
            Node? rightNode = null)
        {
            Character = character;
            Frequency= frequency;
            Left = leftNode;
            Right = rightNode;
        }
    }
    
    private List<Node> HeapNodes { get; set; }= new();
    private Node Left;
    private Node Right;
    

    /// <summary>
    ///     Opens the file for a read and returns the bytes.
    /// </summary>
    /// <param name="absolutePath"></param>
    /// <returns>A byte area of the content of the file.</returns>
    public byte[] OpenFile(string absolutePath)
    {
        if (File.Exists(absolutePath))
        {
            File.Open(absolutePath, FileMode.Open);
        }
        return File.ReadAllBytes(absolutePath);
    }

    /// <summary>
    ///     Makes a frequency table from the file opened. 
    /// </summary>
    /// <param name="data">data</param>
    /// <returns>Huffman encoding frequency table.</returns>
    public Dictionary<Char, int> CharacterFreqTable(byte[] data)
    {
        string dictionaryData = Encoding.UTF8.GetString(data); // Alternative BitConverter.ToString(data);
        Dictionary<char, int> freqTable = new Dictionary<char, int>();
        foreach (var ch in dictionaryData)
        {
            if (!freqTable.TryAdd(ch, 1))
            {
                freqTable.Add(ch, freqTable[ch]+1);
            }
        }
        return freqTable;
    }
    
    /// <summary>
    ///     Insert a new element into a heap DS.
    /// </summary>
    /// <param name="element"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Insert(int element)
    {
        // how do i do this?
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Removes an element from a heap.
    /// </summary>
    /// <param name="element"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Remove(int element)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///    Looks for a parent of an element given an idx provided.
    /// </summary>
    /// <param name="idx"></param>
    /// <returns></returns>
    public int Parent(int idx)
    {
        return (idx-1) / 2;
    }

    /// <summary>
    ///     Given an index I should get the index of the left-child. 
    /// </summary>
    /// <param name="idx"></param>
    /// <returns> Index of the left-child. </returns>
    public int LeftChild(int idx)
    {
        return (2 * idx) + 1;
    }

    /// <summary>
    ///     Given an index I should get the index of the right-child. 
    /// </summary>
    /// <param name="idx"></param>
    /// <returns> Index of the right-child. </returns>

    public int RightChild(int idx)
    {
        return (2 * idx) + 2;
    }

    public bool HasLeftChild(int index)
    {
        return LeftChild(index) < HeapNodes.Count;
    }

    public bool HasRightChild(int index)
    {
        return RightChild(index) < HeapNodes.Count;
    }

    public void Swap(int value1, int value2)
    {
        (HeapNodes[value1], HeapNodes[value2]) = (HeapNodes[value2], HeapNodes[value1]);
    }

    public void HeapifyDown(int idx)
    {
        throw new NotImplementedException();
    }

    public void HeapifyUp(int idx)
    {
        throw new NotImplementedException();
    }
}





