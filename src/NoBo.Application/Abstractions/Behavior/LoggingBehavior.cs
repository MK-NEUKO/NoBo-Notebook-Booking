using MediatR;
using Microsoft.Extensions.Logging;
using NoBo.Application.Abstractions.Messaging;

namespace NoBo.Application.Abstractions.Behavior;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;

        try
        {
            _logger.LogInformation("Executing Command {Command}", name);

            var result = await next();

            _logger.LogInformation("Command {Command} progressed successfully", name);

            return result;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Command {Command} progressing failed", name);
            throw;
        }
    }
}