﻿public abstract class BaseService<T>
{
    protected readonly ILogger<T> Logger;

    protected BaseService(ILogger<T> logger)
    {
        Logger = logger;
    }
}