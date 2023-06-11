using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace batch15webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IAuthManager _manager;
        private readonly ILoggerManager _loggerManager;

        public ProductController(IAuthManager manager, ILoggerManager loggerManager)
        {
            _manager = manager;
            _loggerManager = loggerManager;
        }
        [Authorize("Admin")]
        [HttpPost]
        public IActionResult Create([FromBody]CreateRequestModel product)
        {
            // var productExist = _context.Products.Any(p => p.Name == product.Name);
            if (false)
            {
                _loggerManager.LogError($"{product.Name} already exist");
                return BadRequest($"{product.Name} already exist");
            }
            var newProduct = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };
            // _context.Products.Add(newProduct);
            // _context.SaveChanges();
            _loggerManager.LogInfo($"{product.Name} Sucessfully Created");

            return Ok(new { Product = product, Message = $"product with name {product.Name} craeted successfully" });
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequestModel model)
        {
            var user = batch15webAPI.User.Users.SingleOrDefault(a => a.Email == model.Email && a.PassWord == model.PassWord);
            if(user == null)
            {
                return BadRequest();
            }
           var token = _manager.GenerateToken(user);

            return Ok(new { Product = user, Message = $"User with email {user.Email} Logged in successfully" , Token = token});
        }


        // [HttpGet("{id}")]
        // public IActionResult Get([FromRoute] int id)
        // {
        //     var product = _context.Products.SingleOrDefault(p => p.Id == id);
        //     if (product == null)
        //     {
        //         return NotFound($"product with {id} does not exist");
        //     }
        //     return Ok(new { Product = product, Message = "found" });
        // }

        // [HttpGet]
        // public IActionResult GetAll()
        // {
        //     var products = _context.Products.ToList();
        //     return Ok(products);
        // }

        // [HttpPut("{id}")]
        // public IActionResult Update([FromRoute] int id, [FromBody] UpdateRequestModel model)
        // {
        //     var product = _context.Products.SingleOrDefault(p => p.Id == id);
        //     if (product == null)
        //     {
        //         return NotFound($"product with {id} does not exist");
        //     }
        //     product.Name = model.Name;
        //     product.Description = model.Description;
        //     product.Price = model.Price;
        //     _context.Update(product);
        //     _context.SaveChanges();
        //     return Ok(product);

        // }

        // [HttpDelete("{id}")]
        // public IActionResult Delete([FromRoute] int id)
        // {
        //     var product = _context.Products.SingleOrDefault(p => p.Id == id);
        //     if (product == null)
        //     {
        //         return NotFound($"product with {id} does not exist");
        //     }
        //     _context.Remove(product);
        //     _context.SaveChanges();
        //     return Ok($"product deleted");
        // }

        // [HttpGet("locations")]
        // public async Task<IActionResult> GetLocations()
        // {
        //     var client = new HttpClient();
        //     var request = new HttpRequestMessage
        //     {
        //         Method = HttpMethod.Get,
        //         RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/current.json?q=%3CREQUIRED%3E"),
        //         Headers =
        //         {
        //             { "X-RapidAPI-Key", "35d7f2e6cbmshf369599fe08c0d4p125700jsnd589770f079b" },
        //             { "X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com" },
        //          },
        //     };
        //     using var response = await client.SendAsync(request);
        //     response.EnsureSuccessStatusCode();
        //     var body = await response.Content.ReadAsStringAsync();
        //     return Ok(body);
        // }
    }
}
