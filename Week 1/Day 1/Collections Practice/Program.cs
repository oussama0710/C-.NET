int [] array1 = new int[] {1,2,3,4,5,6,7,8,9};
string [] array2= new string[] {"Tim", "Martin", "Nikki", "Sara"};
bool [] array3 = new bool[10];
for (int i=0;i<array3.Length; i++)
{
    if(i%2 == 0)
    {
        array3[i]=true;
    }
    else
    {
        array3[i]=false;
    }

}
// foreach(int i in array1)
// {
//     Console.WriteLine(i);
// }
// foreach(string i in array2)
// {
//     Console.WriteLine(i);
// }
// foreach(bool i in array3)
// {
//     Console.WriteLine(i);
// }
List<string> IceCream = new List<string>() {"pistache","noisettes","kinder bueno","raffaello","strawberry"};
// Console.WriteLine(IceCream.Count);
// Console.WriteLine(IceCream[2]);
IceCream.Remove(IceCream[2]);
// Console.WriteLine(IceCream.Count);

Dictionary<string,string> profile = new Dictionary<string,string>();
Random rand = new Random();
for (int i= 0;i<4;i++)
{
    profile.Add(array2[i], IceCream[rand.Next(0,5)]);
}
foreach (var entry in profile)
{
    Console.WriteLine(entry.Key + " - " + entry.Value);
}