using SignalRApp.Server.Data;

namespace SignalRApp.Tests;

public class LogicTests
{
    [Fact]
    public void CustomAlgoritm_ShouldReturnCorrectValue()
    {
        // (_1+1)*_1+20 = 12
        // (_2+1)*_2+20 = 16
        // (_3+1)*_3+20 = 22

        ILogic _logic = new Logic();

        Assert.True(_logic.CustomAlgoritm(1) == 12);
        Assert.True(_logic.CustomAlgoritm(2) == 16);
        Assert.True(_logic.CustomAlgoritm(3) == 22);

    }

}