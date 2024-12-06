using _api.InputModels;
using _api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace _api.Controllers
{
    [Route("products")]
    [ApiController]
    public class TSpsController : ControllerBase
    {
        private readonly QlbanDtContext context;
        public TSpsController(QlbanDtContext _context)
        {
            context = _context;
        }

        // GET: api
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await context.TSp.Include(x => x.MaTlNavigation).Include(x => x.MaHangNavigation)
                .Select(x => new
                {
                    x.MaSp,
                    x.TenSp,
                    x.MaTlNavigation.TenTl,
                    x.MaHangNavigation.TenHang,
                    x.DonGiaNhap,
                    x.DonGiaBan,
                    x.SoLuong,
                    x.Anh
                })
                .ToListAsync();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                Message = "Ok",
                Product = products
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await context.TSp.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                Message = "Ok",
                Product = product
            });
        }

        [HttpGet("toCreate")]
        public async Task<IActionResult> GetInfoToCreate()
        {
            Random random = new Random();
            int rdNum = random.Next(10000, 99999);
            var productId = "SP" + rdNum.ToString();
            if(await context.TSp.FindAsync(productId) != null)
            {
                rdNum = random.Next(10000, 99999);
                productId = "SP" + rdNum.ToString();
            }
            
            var categories = await context.TTheLoais.ToListAsync();
            var suppliers = await context.THangs.ToListAsync();
            return Ok(new
            {
                productId,
                categories,
                suppliers,
            });
        }

        [HttpPost]
        public async Task<ActionResult<TSp>> AddProduct(InputProduct sp)
        {
            if (sp == null)
            {
                return BadRequest("Product data is null");
            }
            var product = new TSp
            {
                MaSp = sp.MaSp,
                TenSp = sp.TenSp,
                MaTl = sp.MaTl,
                MaHang = sp.MaHang,
                DonGiaNhap = sp.DonGiaNhap,
                DonGiaBan = sp.DonGiaBan,
                Anh = sp.Anh
            };

            await context.TSp.AddAsync(product);
            try
            {
                await context.SaveChangesAsync();
                return CreatedAtAction("GetProductById", new { id = product.MaSp }, product);
            }
            catch (DbUpdateException er)
            {

                return Conflict(new { Message = "Product could not be added.", Details = er.Message });

            }
        }
    }
}
