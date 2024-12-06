using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _api.Models;

namespace _api.Controllers
{
    [Route("invoiceDetail")]
    [ApiController]
    public class TChiTietHdbsController : ControllerBase
    {
        private readonly QlbanDtContext _context;

        public TChiTietHdbsController(QlbanDtContext context)
        {
            _context = context;
        }

        // GET: api/TChiTietHdbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TChiTietHdb>>> GetInvoiceDetail()
        {
            var invoiceDetail = await _context.TChiTietHdbs.Include(x => x.MaSpNavigation).Select(x => new
            {
                x.SoHdb,
                x.MaSpNavigation.TenSp,
                x.Slban,
                x.ThanhTien,
                x.KhuyenMai
            }).ToListAsync();
            return Ok(invoiceDetail);
        }

        // GET: api/TChiTietHdbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TChiTietHdb>> GetInvoiceDetailById(string id)
        {
            if (_context.TChiTietHdbs == null)
            {
                return NotFound();
            }
            var tChiTietHdb = await _context.TChiTietHdbs.FindAsync(id);

            if (tChiTietHdb == null)
            {
                return NotFound();
            }

            return tChiTietHdb;
        }


        // POST: api/TChiTietHdbs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TChiTietHdb>> AddInvoiceDetail(TChiTietHdb tChiTietHdb)
        {
            if (tChiTietHdb == null) { return BadRequest("Invoice Detail is not null!"); }
            var invoiceDetail = new TChiTietHdb
            {
                SoHdb = tChiTietHdb.SoHdb,
                MaSp = tChiTietHdb.MaSp,
                Slban = tChiTietHdb.Slban,
                KhuyenMai = tChiTietHdb?.KhuyenMai,
            };
            await _context.TChiTietHdbs.AddAsync(invoiceDetail);
            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetInvoiceDetailById", new { id = invoiceDetail.SoHdb }, invoiceDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
