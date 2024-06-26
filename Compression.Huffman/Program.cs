// See https://aka.ms/new-console-template for more information

using Compression.Huffman;

Heap heap = new Heap();
var fileByte = heap.OpenFile("/Users/dj/Developer/manning/APS.NET-CORE/Projects/Compression/Compression.Huffman/Heap.cs"); // Opens, reads and returns a byte of the file content

var frequency = heap.CharacterFreqTable(fileByte);

foreach (KeyValuePair<char, int> keyValuePair in frequency)
{
	Console.WriteLine($"{keyValuePair.Key} = {keyValuePair.Value}");
}
// create the forrest here
IList<Heap.Node> forest = new List<Heap.Node>(); 
foreach (KeyValuePair<char, int> entry in frequency)
{
	forest.Add(new Heap.Node(entry.Key, entry.Value));
}
// 







































































// using Compression.Huffman;

// LINQ
// public record Student(int Id, string Name, int Age);

// int[] number = [12, 32, 3, 45, 2, 4, 5, 6, 7, 67, 8, 0, 12, 2, 3, 421, 1, 12, 3245, 52];
//
// var nc = from n in number
//     where n < 12
//     orderby n  
//     select n;
// Console.WriteLine(nc);
//
// IList<Student> students = new List<Student>()
// {
//     new(1, "Alice", 20),
//     new(2, "Bob", 21),
//     new(3, "Charlie", 22),
//     new(4, "David", 23),
//     new(5, "Eve", 24),
//     new(6, "Frank", 25),
//     new(7, "Grace", 26),
//     new(8, "Hank", 27),
//     new(9, "Ivy", 28),
//     new(10, "Jack", 29),
//     new(11, "Kara", 30),
//     new(12, "Liam", 31),
//     new(13, "Mia", 32),
//     new(14, "Nina", 33),
//     new(15, "Owen", 34),
//     new(16, "Paul", 39),
//     new(17, "Quinn", 36),
//     new(18, "Rita", 37),
//     new(19, "Sam", 38),
//     new(20, "Tina", 39),
//     new(21, "Uma", 44),
//     new(22, "Vera", 41),
//     new(23, "Will", 42),
//     new(24, "Xander", 43),
//     new(25, "Yara", 44),
//     new(26, "Zane", 45)
// };
//
// var ni = from student in students
//     join s in students
//     on student.Age equals s.Age
//     select new
//     {
//         name = s.Name,
//         std = student.Name
//     };

// Delegates
// delegate int Mul(int a, int b);
// class MyClass
// {
//     static int Mult(int a, int b)
//     {
//         return a * b;
//     }
//
//     public static void Main()
//     {
//         Mul mul = Mult;
//         var r = mul(2, 4);
//         Console.WriteLine(r);
//     }
// }
//








