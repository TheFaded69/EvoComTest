using EvoComTest.Models.HttpService.DTO;

namespace EvoComTest.Models.AppService;

public interface ICartService : ICartObservable
{
    void AddCartItem(CartItemDTO cartItemDto);
    
    void RemoveCartItem(CartItemDTO cartItemDto);

    void AddCartItemFromShop(ShopItemDTO shopItemDto);

    void RemoveCartItemFromShop(ShopItemDTO shopItemDto);
}