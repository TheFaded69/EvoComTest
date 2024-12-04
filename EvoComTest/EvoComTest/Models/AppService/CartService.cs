using System.Collections.Generic;
using System.Linq;
using EvoComTest.Models.HttpService.DTO;

namespace EvoComTest.Models.AppService;

public class CartService : ICartService
{
    public CartService()
    {
        
    }

    private List<CartItemDTO> _cartItemDtos = [];
    
    public void AddCartItem(CartItemDTO cartItemDto)
    {
        _cartItemDtos.Add(cartItemDto);
        
        Update();
    }

    public void RemoveCartItem(CartItemDTO cartItemDto)
    {
        _cartItemDtos.Remove(cartItemDto);
        
        Update();
    }

    public void AddCartItemFromShop(ShopItemDTO shopItemDto)
    {
        _cartItemDtos.Add(new CartItemDTO
        {
            Count = shopItemDto.Count,
            Label = shopItemDto.Label
        });
        
        Update();
    }

    public void RemoveCartItemFromShop(ShopItemDTO shopItemDto)
    {
        _cartItemDtos.Remove(_cartItemDtos.First(cart => cart.Label == shopItemDto.Label));
        
        Update();
    }
    
    private List<ICartObserver> _observers = []; 
    
    public void AddObserver(ICartObserver cartObserver)
    {
        _observers.Add(cartObserver);
    }

    public void RemoveObserver(ICartObserver cartObserver)
    {
        _observers.Remove(cartObserver);
    }

    public void Update()
    {
        _observers.ForEach(o => o.Update(_cartItemDtos));
    }

    
}