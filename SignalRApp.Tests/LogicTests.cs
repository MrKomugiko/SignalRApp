using SignalRApp.Server.Data;

namespace SignalRApp.Tests;

public class LogicTests
{
    [Fact]
    public void CustomAlgoritm_ShouldReturnCorrectValue()
    {
        // (_1+1)*_1+10 = 12
        // (_2+1)*_2+10 = 16
        // (_3+1)*_3+10 = 22

        ILogic _logic = new Logic();

        Assert.True(_logic.CustomAlgoritm(1) == 12);
        Assert.True(_logic.CustomAlgoritm(2) == 16);
        Assert.True(_logic.CustomAlgoritm(3) == 22);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]

    public void CustomAlgoritm_magicNumberShouldBe10(int input)
    {
        ILogic _logic = new Logic();

        Assert.Equal<int>(expected:10, actual:_logic.CustomAlgoritm(input)- (input*input + input));
    }

}