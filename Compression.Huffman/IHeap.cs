using System.Collections;

namespace Compression.Huffman;

public interface IHeap
{
    
    void Insert(int element);
    void Remove(int element);
    int Parent(int idx);
    int LeftChild(int idx);
    int RightChild(int idx);
    bool HasLeftChild(int index);
    bool HasRightChild(int index);
    void Swap(int value1, int value2);
    void HeapifyDown(int idx);
    void HeapifyUp(int idx);
    byte[]? OpenFile(string absolutePath);
    Dictionary<Char, int> CharacterFreqTable(byte[]? data);
}