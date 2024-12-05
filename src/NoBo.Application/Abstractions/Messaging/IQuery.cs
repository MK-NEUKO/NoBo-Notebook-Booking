using MediatR;
using NoBo.Domain.Abstractions;

namespace NoBo.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}