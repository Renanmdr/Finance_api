﻿namespace Finance.Domain.Repositories;
public interface IUnitOfWork
{
    Task Commit();
}