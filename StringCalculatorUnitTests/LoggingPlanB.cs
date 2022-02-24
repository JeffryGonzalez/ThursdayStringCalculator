
namespace StringCalculatorUnitTests;

public class LoggingPlanB
{
    private readonly StringCalculator _calculator;
    private readonly Mock<ILogger> _stubbedLogger;
    private readonly Mock<IWebService> _mockedWebService;
    public LoggingPlanB()
    {
        _stubbedLogger = new Mock<ILogger>();
        _mockedWebService = new Mock<IWebService>();
        _calculator = new StringCalculator(_stubbedLogger.Object, _mockedWebService.Object);

      

    }

    [Theory]
    [InlineData("", "Blammo!")]
    [InlineData("1,2", "Disk Is Full")]
    public void Tacos(string numbers, string message)
    {
        _stubbedLogger.Setup(c => c.Write(It.IsAny<string>()))
          .Throws(new LoggerException(message));
        // When
        _calculator.Add(numbers); // blammo!
        // Then
        _mockedWebService.Verify(w => w.WriteLoggingError(message));
    }
}
