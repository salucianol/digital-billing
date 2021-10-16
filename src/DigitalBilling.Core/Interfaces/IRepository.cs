using DigitalBilling.Core.Entities;
using System;
using System.Collections.Generic;

namespace DigitalBilling.Core.Interfaces {
    public interface IRepository<T> where T : BaseEntity {
        ICollection<T> GetAll();

        T GetById(Guid id);

        void Persist(T entity);

        void Remove(T entity);
    }
}
