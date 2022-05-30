namespace Uamqp.Lib;

public class Consumer
{
    private readonly IntPtr _loop;
    public readonly IntPtr _ptr;

    public Consumer(IntPtr loop, IntPtr ptr)
    {
        _loop = loop;
        _ptr = ptr;
    }
}
