using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CallData.Models.Abstract;

namespace CallData.Models.Concrete
{
    public class BillRepository : IBillRepository
    {
        public Bill GetById(int id)
        {
            return bills.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Bill> GetAll()
        {
            return bills;
        }

        private readonly IList<Bill> bills = new List<Bill>()
        {
            new Bill {Id = 1, Name = "Tomato Soup"},
            new Bill {Id = 2, Name = "Yo-yo"},
            new Bill {Id = 3, Name = "Hammer"}
        };


        //[HttpPost]
        //public void CreateBill([FromBody]Bill product)
        //{
        //    bills.Add(product);
        //}

        //public void DeleteBill(int id)
        //{
        //    bills.Remove(bills.Where(pr => pr.Id == id)
        //        .ToList()
        //        .FirstOrDefault());
        //}

        //[HttpPut]
        //public void EditBill(int id, [FromBody]Bill product)
        //{
        //    //Some codes
        //}
    }
}