using System.Text;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Before AwaitRead: " + Thread.CurrentThread.ManagedThreadId);
        AwaitRead();
        Console.ReadLine();
    }

    private static async void AwaitRead()
    {
        using (FileStream fs = new FileStream(@"C:\windows\system32\drivers\etc\services", FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 4096, true))
        {
            byte[] buf = new byte[fs.Length];

            Console.WriteLine("Before ReadAsync: " + Thread.CurrentThread.ManagedThreadId);
            await fs.ReadAsync(buf, 0, buf.Length);
            Console.WriteLine("After ReadAsync: " + Thread.CurrentThread.ManagedThreadId);

            string txt = Encoding.UTF8.GetString(buf);
            Console.WriteLine(txt);
        }
    }
}