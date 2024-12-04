using System.Collections.Generic;
using EvoComTest.Models.HttpService.DTO;

namespace EvoComTest.Models.AppService;

public interface ICartObserver
{
    void Update(List<CartItemDTO> cartItemDto);
}