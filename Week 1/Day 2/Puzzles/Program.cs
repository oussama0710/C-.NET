static int[] RandomArray()
{
    int [] array = new int[10];
    Random rand = new Random();
    
    for (int i=0;i<array.Length;i++)
    {
        array[i]= rand.Next(5,26);
    }
    Console.WriteLine("Minimum number is " + array.Min());
    Console.WriteLine("Maximum number is " + array.Max());
    Console.WriteLine("The sum of the array is " + array.Sum());
    return array;
}
// Console.WriteLine(RandomArray());
static string TossCoin()
{
    Console.WriteLine("Tossing a Coin!");
    Random rand = new Random();
    int coin = rand.Next(0,2);
    if (coin == 0)
    {
        Console.WriteLine("Heads"); 
        return "Heads";
    }
    else
    {
        Console.WriteLine("Tails"); 
        return "Tails";
    }
}
// TossCoin();
static List<string> Names()
{
    List<string> Names = new List<string>(){"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};

    for (int i=0;i<Names.Count;i++)
    {
        if(Names[i].Length<=5)
        {
            Console.WriteLine(Names[i]);
            Names.RemoveAt(i);
            
        }
    }
    return Names;
}
Console.WriteLine(Names());