using SignalRApp.Server.Data;

namespace SignalRApp.Tests;

public class LogicTests
{
    [Fact]
    public void CustomAlgoritm_ShouldReturnCorrectValue()
    {
        // (_1+1)*_1+20 = 22
        // (_2+1)*_2+20 = 26
        // (_3+1)*_3+20 = 32

        ILogic _logic = new Logic();

        Assert.True(_logic.CustomAlgoritm(1) == 22);
        Assert.True(_logic.CustomAlgoritm(2) == 26);
        Assert.True(_logic.CustomAlgoritm(3) == 32);

    }

}