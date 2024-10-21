﻿using MPEA.Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public Task<int> SaveChangesAsync();
    }
}
