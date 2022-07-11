using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TennesseeDiscs.Models;
using TennesseeDiscs.Repositories;

namespace TennesseeDiscs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartDiscController : ControllerBase
    {
        private readonly ICartDiscRepository _cartDiscRepository;
        public CartDiscController(ICartDiscRepository cartDiscRepository)
        {
            _cartDiscRepository = cartDiscRepository;
        }



        // https://localhost:5001/api/cartdisc/
        [HttpPost]
        public IActionResult Post(int cartId, int discId, int userId)
        {
            _cartDiscRepository.AddDiscToCart(cartId, discId, userId);
            return NoContent();
        }


        // https://localhost:5001/api/cartdisc/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, int cartId)
        {
            _cartDiscRepository.RemoveDiscFromCart(cartId, id);
            return NoContent();
        }



    }
}
