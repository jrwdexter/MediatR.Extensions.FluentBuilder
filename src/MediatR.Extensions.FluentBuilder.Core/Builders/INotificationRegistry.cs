﻿namespace MediatR.Extensions.FluentBuilder.Builders
{
    public interface INotificationRegistry<out TNotification> where TNotification : INotification
    {
        INotificationRegistry<TNotification> AddHandler<THandler>() where THandler : class, INotificationHandler<TNotification>;
    }
}