﻿using Microsoft.EntityFrameworkCore;

namespace CoreBussiness.RepsPattern;

public interface IUnitOfWork:IAsyncDisposable
{
    DbSet<TEntity> Set<TEntity>() where TEntity:class;
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken  = new CancellationToken() );
}