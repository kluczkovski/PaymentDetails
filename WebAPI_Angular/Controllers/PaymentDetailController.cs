using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WebAPI_Angular.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_Angular.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly PaymentDetailContext _db;

        public PaymentDetailController(PaymentDetailContext paymentDetailContext)
        {
            _db = paymentDetailContext;
        }

        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
        {
            return await _db.PaymentDetails.ToListAsync();
        }

        // GET api/PaymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>>  GetPaymentDetail(int id)
        {
            var paymentDetail = await _db.PaymentDetails.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }


        // POST api/PaymentDetail/
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>>  PostPaymentDetail([FromBody]PaymentDetail paymentDetail)
        {
            _db.PaymentDetails.Add(paymentDetail);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetail", new { id = paymentDetail.PaymentDetailId }, paymentDetail);
        }

        // PUT api/PaymentDetail/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPaymentDetail(int id, [FromBody]PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.PaymentDetailId)
            {
                return BadRequest();
            }

            _db.Entry(paymentDetail).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }



        // DELETE api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentDetail>> DeletePaymentDetail(int id)
        {
            var paymentDetail = await _db.PaymentDetails.FindAsync(id);
            if ( paymentDetail == null)
            {
                return NotFound();
            }

            _db.PaymentDetails.Remove(paymentDetail);
            await _db.SaveChangesAsync();
            return paymentDetail;
        }

        private bool PaymentDetailExists(int id)
        {
            return _db.PaymentDetails.Any(e => e.PaymentDetailId == id);
        }
    }
}
