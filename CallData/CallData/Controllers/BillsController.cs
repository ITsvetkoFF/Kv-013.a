using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CallData.Models;
using CallData.Models.Abstract;

namespace CallData.Controllers
{
    public class BillsController : ApiController
    {
        private IBillRepository repository;

        public BillsController(IBillRepository repository)
        {
            this.repository = repository;
        }

        public IHttpActionResult Get(int id)
        {
            var bill = repository.GetById(id);
            if (bill == null)
            {
                return NotFound();
            }
            return Ok(bill);
        }

        public IEnumerable<Bill> GetAll()
        {
            var bill = repository.GetAll();
            return bill;

        }
    }
}
