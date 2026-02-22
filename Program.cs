class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        string[] requiredIngredients = Console.ReadLine()!.Split();
        string[] usedIngredients = Console.ReadLine()!.Split();

        for (int i = 0; i < requiredIngredients.Length; ++i)
        {
            string requiredIngredient = requiredIngredients[i];

            bool contained = false;
            {
                for (int j = 0; j < usedIngredients.Length; ++j)
                {
                    if (requiredIngredient == usedIngredients[j])
                    {
                        contained = true;
                        break;
                    }
                }
            }

            if (contained == false)
            {
                Console.Write(requiredIngredient);
                return;
            }
        }
    }
}