using System.Collections.Generic;
using Models;

namespace CallData.Models.Abstract
{
    public interface IBillRepository
    {
        Bill GetById(int id);

        IEnumerable<Bill> GetAll();

        void Add(Bill product);

        void Delete(int id);

        void Update(int id, Bill product);
    }
}