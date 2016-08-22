using HyperApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperApplication.EFCore
{
    public class DataContext<T> : DbContext, IDataContext<T>
    {
        public DataContext(DbContextOptions<DataContext<T>> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerID).IsRequired();
            });
        }

        public override int SaveChanges()
        {
            var changes = base.SaveChanges();
            return changes;
        }

        public void Get()
        {

        }
    }
}
