namespace Uamqp.Lib;

public class Loop
{
    public readonly IntPtr _ptr;

    public Loop()
    {
        _ptr = LoopAsync.CreateAsyncLoop();
    }

    public async Task<Connection> ConnectAsync() => new(_ptr, await LoopAsync.ConnectAsync(_ptr));
}
