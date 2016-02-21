using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CallData.Models;

namespace CallData.Controllers
{
    public class BillsController : ApiController
    {
        private IList<Bill> bills = new List<Bill>()
        {
            new Bill {Id = 1, Name = "Tomato Soup"},
            new Bill {Id = 2, Name = "Yo-yo"},
            new Bill {Id = 3, Name = "Hammer"}
        };

        public IEnumerable<Bill> GetAllBills()
        {
            return bills;
        }

        public Bill GetBill(int id)
        {
            return bills.Where(pr => pr.Id == id)
                .ToList()
                .FirstOrDefault();
        }

        [HttpPost]
        public void CreateBill([FromBody]Bill product)
        {
            bills.Add(product);
        }

        public void DeleteBill(int id)
        {
            bills.Remove(bills.Where(pr => pr.Id == id)
                .ToList()
                .FirstOrDefault());
        }

        [HttpPut]
        public void EditBill(int id, [FromBody]Bill product)
        {
            //Some codes
        }
    }

}
