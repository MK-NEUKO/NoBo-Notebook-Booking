using NoBo.Domain.Abstractions;

namespace NoBo.Domain.Users.Events;

public record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;