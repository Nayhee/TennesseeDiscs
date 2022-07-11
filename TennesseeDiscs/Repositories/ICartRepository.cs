using TennesseeDiscs.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace TennesseeDiscs.Repositories
{
    public interface ICartRepository
    {

        void AddCart(Cart cart);
        //void AddDiscToCart(int cartId, int discId, int userId);
        //void RemoveDiscFromCart(int cartId, int discId);
        List<Disc> GetACartsDiscs(int cartId);
        Cart GetCartById(int cartId);

        void DeleteCart(int cartId);



        Cart GetUsersCurrentCart(int userId);
    
    }
}