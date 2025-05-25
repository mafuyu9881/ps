namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        //var task3 = Method3Async();
        //var task5 = Method5Async();

        var task3 = Task.Factory.StartNew(() =>
        {
            Thread.Sleep(3000);
            return 3;
        });
        var task5 = Task.Factory.StartNew(() =>
        {
            Thread.Sleep(5000);
            return 5;
        });

        Task.WaitAll(task3, task5);

        Console.WriteLine(task3.Result + task5.Result);
    }

    private static Task<int> Method3Async()
    {
        return Task.Factory.StartNew(() =>
        {
            Thread.Sleep(3000);
            return 3;
        });
    }

    private static Task<int> Method5Async()
    {
        return Task.Factory.StartNew(() =>
        {
            Thread.Sleep(5000);
            return 5;
        });
    }
}