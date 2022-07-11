namespace TennesseeDiscs.Repositories
{
    public interface ICartDiscRepository
    {
        void AddDiscToCart(int cartId, int discId, int userId);
        void RemoveDiscFromCart(int cartId, int discId);
    }
}