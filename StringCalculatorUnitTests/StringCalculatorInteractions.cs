

namespace StringCalculatorUnitTests;

public class StringCalculatorInteractions
{

    private readonly StringCalculator calculator;
    private readonly Mock<ILogger> loggerMock;
    public StringCalculatorInteractions()
    {  // Given
        loggerMock =new Mock<ILogger>();
        calculator = new StringCalculator(loggerMock.Object, new Mock<IWebService>().Object);
    }


    [Theory]
    [InlineData("1,2", "3")]
    [InlineData("2,2", "4")]
    [InlineData("1,2,3,4,5,6,7,8,9", "45")]
    [InlineData("", "0")]
    public void FinalAnswerIsWrittenToTheLogger(string numbers, string expected)
    {
        // When
       calculator.Add(numbers);

        // Then??
        // Did the logger get "3" written to it?
        loggerMock.Verify(logger => logger.Write(expected));
    }


}
