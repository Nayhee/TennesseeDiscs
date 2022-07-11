using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TennesseeDiscs.Models;
using TennesseeDiscs.Repositories;

namespace TennesseeDiscs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }


        // https://localhost:5001/api/cart/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cart = _cartRepository.GetCartById(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        // https://localhost:5001/api/cart/
        [HttpPost]
        public IActionResult Post(Cart cart)
        {
            _cartRepository.AddCart(cart);
            return CreatedAtAction("Get", new { id = cart.Id }, cart);
        }


        // https://localhost:5001/api/disc/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cartRepository.DeleteCart(id);
            return NoContent();
        }



    }
}
