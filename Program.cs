using System.Runtime.InteropServices;

namespace CSharp;

public delegate void PtrCallack(IntPtr ptr);
public delegate void Callack();

public class Program
{
    public static async Task Main(string[] args)
    {
        IntPtr loop = create_async_loop();
        Console.WriteLine($"Loop ptr: {loop}");

        connect(loop, Marshal.GetFunctionPointerForDelegate(new PtrCallack((IntPtr connPtr) =>
        {
            Console.WriteLine($"Connection ptr: {connPtr}");

            create_channel(loop, connPtr, Marshal.GetFunctionPointerForDelegate(new PtrCallack((IntPtr channelPtr) =>
            {
                Console.WriteLine($"Channel ptr: {channelPtr}");

                queue_declare(loop, channelPtr, Marshal.GetFunctionPointerForDelegate(new Callack(() =>
                {
                    Console.WriteLine($"Declared queue!");

                    create_channel(loop, connPtr, Marshal.GetFunctionPointerForDelegate(new PtrCallack((IntPtr channelPtr) =>
                    {
                        Console.WriteLine($"Channel ptr: {channelPtr}");

                        basic_consume(loop, channelPtr, Marshal.GetFunctionPointerForDelegate(new PtrCallack((IntPtr consumerPtr) =>
                        {
                            Console.WriteLine($"Consumer ptr: {consumerPtr}");
                        })));
                    })));
                })));
            })));
        })));

        await Task.Delay(10000);
    }

    [DllImport("../../../../lib/target/debug/libuamqp.so")]
    private static extern IntPtr create_async_loop();

    [DllImport("../../../../lib/target/debug/libuamqp.so")]
    private static extern void connect(IntPtr rnt, IntPtr callback);

    [DllImport("../../../../lib/target/debug/libuamqp.so")]
    private static extern void create_channel(IntPtr rnt, IntPtr conn, IntPtr callback);

    [DllImport("../../../../lib/target/debug/libuamqp.so")]
    private static extern void queue_declare(IntPtr rnt, IntPtr channel, IntPtr callback);

    [DllImport("../../../../lib/target/debug/libuamqp.so")]
    private static extern void basic_consume(IntPtr rnt, IntPtr channel, IntPtr callback);
}
