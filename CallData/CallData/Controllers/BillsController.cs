using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CallData.Models;
using CallData.Models.Abstract;
using CallData.Models.Concrete;

namespace CallData.Controllers
{
    public class BillsController : ApiController
    {
        private readonly IBillRepository _billRepository;

        public BillsController(IBillRepository billRepository)
        {
            this._billRepository = new BillRepository();
        }

        [HttpGet]
        public IEnumerable<Bill> Get()
        {
            return _billRepository.GetAll();
        }

        [HttpPost]
        public void Add([FromBody]Bill product)
        {
            _billRepository.Add(product);
        }
        
        [HttpDelete]
        public void Delete(int id)
        {
            _billRepository.Delete(id);
        }

        [HttpPut]
        public void Update(int id, [FromBody]Bill product)
        {
            _billRepository.Update(id, product);
        }
    }
}
