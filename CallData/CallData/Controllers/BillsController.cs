using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CallData.Models;
using CallData.Models.Abstract;
using CallData.Models.Concrete;
using Models;

namespace CallData.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BillsController : ApiController
    {
        private readonly IBillRepository _billRepository;

        public BillsController()
        {
            this._billRepository = new BillRepository();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_billRepository.GetAll());
        }

        public IHttpActionResult GetBill(int id)
        {
            Bill bill = _billRepository.GetById(id);
            return Ok(bill);
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
