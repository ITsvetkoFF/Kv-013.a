using System.Collections.Generic;

namespace CallData.Models.Abstract
{
    public interface IBillRepository
    {
        Bill GetById(int id);

        IEnumerable<Bill> GetAll();
    }
}