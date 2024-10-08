﻿using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class AccountRepository : IAccountRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public AccountRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;
        public async Task<IEnumerable<Account>> GetAllByOwnerIdAsync(int ownerId, CancellationToken cancellationToken = default) =>
            await _dbContext.Accounts.Where(x => x.OwnerId == ownerId).ToListAsync(cancellationToken);

        public async Task<Account> GetByIdAsync(int accountId, CancellationToken cancellationToken = default) =>
            await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Id == accountId, cancellationToken);

        public void Insert(Account account) => _dbContext.Accounts.Add(account);
        public void Remove(Account account) => _dbContext.Accounts.Remove(account);
    }
}
