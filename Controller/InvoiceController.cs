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
using _api.ViewModel;

namespace _api.Controllers
{
    [Route("invoices")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly PhoneManagement _context;

        public InvoicesController(PhoneManagement context)
        {
            _context = context;
        }

        // GET: api/Invoices
        [HttpGet]
        public ActionResult<IEnumerable<ViewInvoice>> GetInvoice()
        {
            var invoices = _context.Invoices.Include(x => x.UserIdNavigation).Include(x => x.InvoiceDetails).ToList();
            var result = new List<ViewInvoice>();
            foreach (var invoice in invoices)
            {
                var tempInvoice = new ViewInvoice();
                tempInvoice.InvoiceId = invoice.InvoiceId;
                tempInvoice.SaleDate = invoice.SaleDate.ToString("yyyy-MM-dd" + " " + "HH:mm:ss");
                tempInvoice.TotalPrice = invoice.TotalPrice;
                tempInvoice.FullName = invoice.UserIdNavigation!.FullName;

                var invoiceDetails = new List<ViewInvoiceDetail>();
                foreach (var invoiceDetail in invoice.InvoiceDetails)
                {
                    var tempInvoiceDetail = new ViewInvoiceDetail();
                    var product = _context.Product.Where(x => x.ProductId == invoiceDetail.ProductId).FirstOrDefault();
                    tempInvoiceDetail.InvoiceId = invoiceDetail.InvoiceId;
                    tempInvoiceDetail.ProductId = invoiceDetail.ProductId;
                    tempInvoiceDetail.ProductName = product!.ProductName;
                    tempInvoiceDetail.SaleQuantity = invoiceDetail.SaleQuantity;
                    tempInvoiceDetail.Discount = invoiceDetail.Discount;
                    tempInvoiceDetail.Price = invoiceDetail.Price;

                    invoiceDetails.Add(tempInvoiceDetail);
                }
                tempInvoice.InvoiceDetails = invoiceDetails;
                result.Add(tempInvoice);
            }
            return Ok(result);
        }
        [HttpGet("toCreate")]
        public async Task<ActionResult<IEnumerable<ViewInvoice>>> GetInvoiceToCreate()
        {
            Random random = new Random();
            int rdNum = random.Next(10000, 99999);
            var invoiceId = "HDB" + rdNum.ToString();

            do
            {
                rdNum = random.Next(10000, 99999);
                invoiceId = "HDB" + rdNum.ToString();
            } while (await _context.Invoices.FindAsync(invoiceId) != null);
            var customers = await _context.Users.Where(x => x.AreaId == 2).ToListAsync();
            var products = await _context.Product.ToListAsync();
            var datetime = DateTime.Now.ToString("yyyy-MM-dd" + "T" + "HH:mm:ss");
            return Ok(new
            {
                invoiceId,
                datetime,
                customers,
                products,
            });
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewInvoice>> GetInvoiceById(string id)
        {
            var invoice = await _context.Invoices.Where(x => x.InvoiceId == id).Select(t => new
            {
                t.InvoiceId,
                t.SaleDate,
                t.UserId,
                t.TotalPrice,
                t.InvoiceDetails

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

        // POST: api/Invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ViewInvoice>> AddInvoice([FromBody] InputInvoice inputInvoice)
        {
            if (inputInvoice == null)
            {
                return BadRequest("Data is not null");
            }
            if (_context.Invoices.FirstOrDefault(x => x.InvoiceId == inputInvoice.InvoiceId) != null)
            {
                return BadRequest("InvoiceId is existed!");
            }

            var invoice = new Invoice
            {
                InvoiceId = inputInvoice.InvoiceId,
                SaleDate = inputInvoice.SaleDate,
                TotalPrice = inputInvoice.TotalPrice,
                UserId = inputInvoice.UserId
            };

            await _context.Invoices.AddAsync(invoice);

            foreach (var detail in inputInvoice.InvoiceDetails)
            {
                var product = _context.Product.Where(x => x.ProductId == detail.ProductId).FirstOrDefault();
                if (product != null)
                {
                    product.Quantity -= detail.SaleQuantity;
                }
                var invoiceDetail = new InvoiceDetail
                {
                    InvoiceId = detail.InvoiceId,
                    ProductId = detail.ProductId,
                    SaleQuantity = detail.SaleQuantity,
                    Discount = detail.Discount,
                    Price = detail.Price,   
                };

                await _context.InvoiceDetails.AddAsync(invoiceDetail);
            }

            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetInvoiceById", new { id = invoice.InvoiceId }, invoice);
            }
            catch (DbUpdateException er)
            {

                return Conflict(new { Message = "Invoice could not be added.", Details = er.Message });

            }
        }
    }
}
