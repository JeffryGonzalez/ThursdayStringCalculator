
using System.Linq;

namespace StringCalculatorUnitTests;

public class StringCalculator
{
    private readonly ILogger _logger;
    private readonly IWebService _webService;
    public StringCalculator(ILogger logger, IWebService webService)
    {
        _logger = logger;
        _webService = webService;
    }

    public int Add(string numbers)
    {

        int result = numbers switch
        {
            "" => 0,
            _ => numbers.Split(',').Select(int.Parse).Sum()
        };

        try
        {
            _logger.Write(result.ToString());
        }
        catch (LoggerException ex)
        {

            _webService.WriteLoggingError(ex.Message);
        }
        return result;
    }
}
