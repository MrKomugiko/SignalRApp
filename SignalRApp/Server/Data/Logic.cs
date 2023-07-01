using SignalRApp.Shared;

namespace SignalRApp.Server.Data;

public class Logic : ILogic
{
    public Logic()
    {

    }

    public int CustomAlgoritm(int a)
    {
       return (a + 1) * a + 20;
    }
}
