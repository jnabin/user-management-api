﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Behaviors
{
    internal sealed class LoggingBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseCommand
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var name = request.GetType().Name;
            try
            {
                _logger.LogInformation("Executing command {Command}", name);
                var result = await next();
                _logger.LogInformation("Command {Command} processed successfully", name);
                return result;
            } catch (Exception ex)
            {
                _logger.LogError(ex, "command {Command} processing failed", name);
                throw;
            }
        }
    }
}
