using EvoComTest.Models.AppService;
using EvoComTest.Models.HttpService;

namespace EvoComTest.Views;

/// <summary>
/// Статичные сервисы для работы дизайнера. Используются только в конструкторах по умолчанию без параметров типа ctor()
/// </summary>
public static class DesignData
{
    public static readonly IShopService ShopService = new ShopService();
    public static readonly IPageMediator PageMediator = new PageMediator();
    public static readonly ICartService CartService = new CartService();
}