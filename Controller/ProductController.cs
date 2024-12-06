using _api.InputModels;
using _api.Models;
using _api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace _api.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly PhoneManagement context;
        public ProductsController(PhoneManagement _context)
        {
            context = _context;
        }

        // GET: api
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewProduct>>> GetProducts()
        {
            var products = await context.Product.Include(x => x.CategoryIdNavigation).Include(x => x.ManufacturerIdNavigation)
                .Where(x => x.Quantity > 0)
                .Select(x => new
                {
                    x.ProductId,
                    x.ProductName,
                    x.CategoryIdNavigation!.CategoryName,
                    x.ManufacturerIdNavigation!.ManufacturerName,
                    x.InPrice,
                    x.SalePrice,
                    x.Quantity,
                    x.Image
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
        public async Task<ActionResult<ViewProduct>> GetProductById(string id)
        {
            var product = await context.Product.FindAsync(id);
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
        public async Task<ActionResult<IEnumerable<ViewProduct>>> GetInfoToCreate()
        {
            Random random = new Random();
            int rdNum = random.Next(10000, 99999);
            var productId = "SP" + rdNum.ToString();

            do
            {
                rdNum = random.Next(10000, 99999);
                productId = "SP" + rdNum.ToString();
            } while (await context.Invoices.FindAsync(productId) != null);

            var categories = await context.Categorys.ToListAsync();
            var suppliers = await context.Manufacturers.ToListAsync();
            return Ok(new
            {
                productId,
                categories,
                suppliers,
            });
        }

        [HttpPost]
        public async Task<ActionResult<ViewProduct>> AddProduct(InputProduct sp)
        {
            if (sp == null || !ModelState.IsValid)
            {
                return BadRequest("Product data is null");
            }
            var product = new Product
            {
                ProductId = sp.ProductId,
                ProductName = sp.ProductName,
                CategoryId = sp.CategoryId,
                ManufacturerId = sp.ManufacturerId,
                InPrice = sp.InPrice,
                SalePrice = sp.SalePrice,
                Quantity = sp.Quantity,
                Image = sp.Image
            };

            await context.Product.AddAsync(product);

            try
            {
                await context.SaveChangesAsync();
                return CreatedAtAction("GetProductById", new { id = product.ProductId }, product);
            }
            catch (DbUpdateException er)
            {

                return Conflict(new { Message = "Product could not be added.", Details = er.Message });

            }
        }
    }
}
