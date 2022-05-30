using Uamqp.Lib;

namespace CSharp;

public delegate void PtrCallack(IntPtr ptr);

public class Program
{
    public static async Task Main(string[] args)
    {
        Loop loop = new();
        Console.WriteLine($"Loop ptr: {loop._ptr}");

        Connection conn = await loop.ConnectAsync();
        Console.WriteLine($"Connection ptr: {conn._ptr}");

        Channel channel = await conn.CreateChannelAsync();
        Console.WriteLine($"Channel ptr: {channel._channelPtr}");

        await channel.QueueDeclareAsync();
        Console.WriteLine($"Declared queue!");

        await Task.WhenAll(Enumerable.Range(1, 5).Select(async (_) =>
        {
            Channel channel1 = await conn.CreateChannelAsync();
            Console.WriteLine($"Channel ptr: {channel1._loopPtr}");

            Consumer consumer = await channel1.BasicConsumeAsync();
            Console.WriteLine($"Consumer ptr: {consumer._ptr}");
        }));

        Console.WriteLine($"Done");
        await Task.Delay(10000);
    }
}
