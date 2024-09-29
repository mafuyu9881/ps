internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();
        
        LinkedList<int> numbers = new();
        for (int i = 0; i < tokens.Length; ++i)
        {
            int number = int.Parse(tokens[i]);
            
            if (numbers.Count > 0)
            {
                LinkedListNode<int>? objective_node;
                for (objective_node = numbers.First; objective_node != null; objective_node = objective_node.Next)
                {
                    if (number < objective_node.Value)
                    {
                        break;
                    }
                }
                
                if (objective_node != null)
                {
                    numbers.AddBefore(objective_node, number);
                }
                else
                {
                    numbers.AddLast(number);
                }
            }
            else
            {
                numbers.AddLast(number);
            }
        }

        Console.Write(numbers.First!.Next!.Value);
    }
}