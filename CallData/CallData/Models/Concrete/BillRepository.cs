using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CallData.Models.Abstract;
using Communication.Common;
using Models;

namespace CallData.Models.Concrete
{
    public class BillRepository : IBillRepository
    {
        private readonly IList<Bill> bills;
        private readonly Parser data;
        private readonly IEnumerable<Bill> bils;

        public BillRepository()
        {
            this.bills = new List<Bill>()
                {
                    new Bill {Id = 1, Name = "Tomato Soup"},
                    new Bill {Id = 2, Name = "Yo-yo"},
                    new Bill {Id = 3, Name = "Hammer"}
                };

            this.data = new Parser();
            this.bils = data.ParseWithDom(@"C:\Users\Андрей\Documents\GitHub\Kv-013.a\CallData\Communication.Common\Content\bills.xml");
        }

        public Bill GetById(int id)
        {
            return bils.Where(r => r.Id == id)
                .ToList()
                .FirstOrDefault();
        }

        public void Add([FromBody]Bill product)
        {
            bills.Add(product);
        }

        public void Delete(int id)
        {
            bills.Remove(bills.Where(pr => pr.Id == id)
                .ToList()
                .FirstOrDefault());
        }

        public void Update(int id, [FromBody]Bill product)
        {
            this.bills.Where(b => b.Id == id)
                .Select(bil =>
                {
                    bil = product;
                    return bil;
                }).ToList();

        }

        public IEnumerable<Bill> GetAll()
        {
            return bils;
        }
    }
}