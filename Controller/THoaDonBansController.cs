using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _api.Models;
using _api.InputModels;
using System.Net.WebSockets;

namespace _api.Controllers
{
    [Route("invoices")]
    [ApiController]
    public class THoaDonBansController : ControllerBase
    {
        private readonly QlbanDtContext _context;

        public THoaDonBansController(QlbanDtContext context)
        {
            _context = context;
        }

        // GET: api/THoaDonBans
        [HttpGet]
        public ActionResult<IEnumerable<THoaDonBan>> GetInvoice()
        {
            var invoices = _context.THoaDonBans.Select(x => new
                            {
                                x.SoHdb,
                                x.MaNguoiDung,
                                x.NgayBan,
                                x.TongHdb,
                                x.TChiTietHdbs
                            }).ToList();
            return Ok(invoices);
        }
        [HttpGet("toCreate")]
        public async Task<ActionResult<IEnumerable<THoaDonBan>>> GetInvoiceToCreate()
        {
            Random random = new Random();
            int rdNum = random.Next(10000, 99999);
            var invoiceId = "HDB" + rdNum.ToString();

            do
            {
                rdNum = random.Next(10000, 99999);
                invoiceId = "HDB" + rdNum.ToString();
            } while (await _context.THoaDonBans.FindAsync(invoiceId) != null);
            var customers = await _context.Nguoidungs.Where(x => x.Idquyen == 2).ToListAsync();
            var products = await _context.TSp.ToListAsync();
            var datetime = DateTime.Now.ToString("yyyy-MM-dd" + "T" + "HH:mm:ss");
            return Ok(new
            {
                invoiceId,
                datetime,
                customers,
                products,
            });
        }

        // GET: api/THoaDonBans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<THoaDonBan>> GetInvoiceById(string id)
        {
            var invoice = await _context.THoaDonBans.Where(x => x.SoHdb == id).Select(t => new
            {
                t.SoHdb,
                t.NgayBan,
                t.MaNguoiDung,
                t.TongHdb,
                t.TChiTietHdbs

            }).FirstOrDefaultAsync();

            if (invoice == null)
            {
                return BadRequest(error: "Invoice not found");
            }
            else
            {
                return Ok(invoice);
            }
        }

        // POST: api/THoaDonBans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<THoaDonBan>> AddInvoice([FromBody] InputInvoice inputInvoice)
        {
            if (inputInvoice == null)
            {
                return BadRequest("Data is not null");
            }
            if (_context.THoaDonBans.FirstOrDefault(x => x.SoHdb == inputInvoice.SoHdb) != null)
            {
                return BadRequest("SoHdb is existed!");
            }

            var invoice = new THoaDonBan
            {
                SoHdb = inputInvoice.SoHdb,
                NgayBan = inputInvoice.NgayBan,
                TongHdb = inputInvoice.TongHdb,
                MaNguoiDung = inputInvoice.MaNguoiDung
            };

            await _context.THoaDonBans.AddAsync(invoice);

            foreach (var detail in inputInvoice.TChiTietHdbs)
            {
                var invoiceDetail = new TChiTietHdb
                {
                    SoHdb = detail.SoHdb,
                    MaSp = detail.MaSp,
                    Slban = detail.Slban,
                    KhuyenMai = detail.KhuyenMai,
                };
                await _context.TChiTietHdbs.AddAsync(invoiceDetail);
            }

            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetInvoiceById", new { id = invoice.SoHdb }, invoice);
            }
            catch (DbUpdateException er)
            {

                return Conflict(new { Message = "Invoice could not be added.", Details = er.Message });

            }
        }
    }
}
