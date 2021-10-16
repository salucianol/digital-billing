using DigitalBilling.Core.Entities;
using DigitalBilling.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBilling.Infrastructure.Data.Repositories {
    public class Repository<T> : IRepository<T> where T : BaseEntity {
        private readonly InvoiceNpgsqlDbContext invoiceDbContext;

        public Repository(InvoiceNpgsqlDbContext invoiceDbContext) {
            this.invoiceDbContext = invoiceDbContext;
        }

        public ICollection<T> GetAll() {
            return (ICollection<T>)invoiceDbContext
                                        .Set<T>()
                                        .AsAsyncEnumerable();
        }

        public T GetById(Guid id) {
            return (T)invoiceDbContext
                        .Set<T>()
                        .Find(id);
        }

        public void Persist(T entity) {
            invoiceDbContext.Set<T>().Add(entity);
        }

        public void Remove(T entity) {
            invoiceDbContext.Set<T>().Remove(entity); 
        }
    }
}
