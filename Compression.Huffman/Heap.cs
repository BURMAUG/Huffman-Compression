using System.ComponentModel;
using System.Text;

namespace Compression.Huffman;

public class Heap : IHeap
{
    public class Node
    {
        public char? Character { get; set; }
        public int Frequency { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        // used to create the forr
        public Node(char character, int frequency)
        {
            Character = character;
            Frequency = frequency;
        }

        /// This is the Heap Node        
        public Node(char? character,
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
    
    internal List<Node> HeapNodes { get; set; }= new();
    internal Node? Left;
    internal Node Right;

    /// <summary>
    ///     Opens the file for a read and returns the bytes.
    /// </summary>
    /// <param name="absolutePath"></param>
    /// <returns>A byte area of the content of the file.</returns>
    public byte[] OpenFile(string absolutePath)
    {
        if (!File.Exists(absolutePath))
            throw new FileNotFoundException("Not found");
        return  File.ReadAllBytes(absolutePath);
    }

    /// <summary>
    ///     Makes a frequency table from the file opened. 
    /// </summary>
    /// <param name="data">data</param>
    /// <returns>Huffman encoding frequency table.</returns>
    public Dictionary<Char, int> CharacterFreqTable(byte[]? data)
    {
        Dictionary<char, int> freqTable = new Dictionary<char, int>();
        if (data != null)
        {
            string dictionaryData = System.Text.Encoding.UTF8.GetString(data);// Encoding.GetString(data); // Alternative BitConverter.ToString(data);
            foreach (var ch in dictionaryData)
            {
                if (!freqTable.ContainsKey(ch))
                    freqTable.Add(ch, 1);
                else
                    freqTable[ch]++;
            }
        }
        return freqTable;
    }

    public void Encoding(Node root, string s, Dictionary<char?, string> frqTable)
    {
        if (root.Left == null && root.Right == null && root.Character != null)
        {
            frqTable[root.Character] = s;
            return;
        }

        if (root.Left != null) Encoding(root.Left, s + "0", frqTable);
        if (root.Right != null) Encoding(root.Right, s + "1", frqTable);
    }


    public void MakeHeap()
    {
        while (HeapNodes.Count > 1)
        {
            Node first =(Node) DeleteMin();
            Node second =(Node) DeleteMin();
            Node parent = new Node(null, first.Frequency + second.Frequency, first, second);
            Insert(parent);
        }
    }

    /// <summary>
    ///     Insert a new element into a heap DS.
    /// </summary>
    /// <param name="element"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Insert(Node node)
    {
        // how do i do this?
        // the invariants are going to be established here.
        HeapNodes.Add(node);
        HeapifyUp(HeapNodes.Count-1);
    }

    /// <summary>
    ///     Removes an element from a heap.
    /// </summary>
    /// <param name="element"></param>
    /// <exception cref="NotImplementedException"></exception>
    public Object DeleteMin()
    {
        if (HeapNodes.Count <= 0)
        {
            throw new IndexOutOfRangeException("Nothing on the heap.");
        }
        // take from the heap
        Node small = HeapNodes[0]; //
        Node last = HeapNodes[^1]; // why? be cause I need to put it at the first position
        HeapNodes[0] = last;
        HeapNodes.Remove(HeapNodes[^1]);
        HeapifyDown(0);
        return small;
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
        int smallest = idx;
        int rightChild = RightChild(idx);
        int leftChild = LeftChild(idx);
        
        if (HasLeftChild(idx) && HeapNodes[idx].Frequency < HeapNodes[smallest].Frequency)
        {
            smallest = leftChild;
        }

        if (HasRightChild(idx) && HeapNodes[idx].Frequency < HeapNodes[smallest].Frequency)
        {
            smallest = rightChild;
        }

        if (smallest != idx)
        {
            Swap(idx, smallest);
            HeapifyDown(smallest);
        }
    }

    public void HeapifyUp(int idx)
    {
        int parentIdx = Parent(idx);
        if (idx > 0 && HeapNodes[idx].Frequency < HeapNodes[parentIdx].Frequency)
        {
            Swap(idx, parentIdx);
            HeapifyUp(parentIdx);
        }
    }
}





