
// Instructions: https://osherove.com/tdd-kata-1

namespace StringCalculatorUnitTests;

public class StringCalculatorTests
{
    private readonly StringCalculator calculator;
    public StringCalculatorTests()
    {
        calculator = new StringCalculator(new Mock<ILogger>().Object, new Mock<IWebService>().Object);
    }
    [Fact]
    public void CalculatorReturnsZeroForEmptyString()
    {
       
        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("983", 983)]
    public void SingleDigits(string numbers, int expected)
    {
        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
   
    public void Unknown(string numbers, int expected)
    {
        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }


}
