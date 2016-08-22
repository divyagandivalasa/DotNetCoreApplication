using HyperApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperApplication.EFCore
{
    public interface IDataContext<T> 
    {
        int SaveChanges();

        void Get();
    }
}
