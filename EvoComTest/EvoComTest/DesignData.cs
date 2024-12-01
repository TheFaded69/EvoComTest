using EvoComTest.Models.AppService;
using EvoComTest.Models.HttpService;

namespace EvoComTest.Views;

public static class DesignData
{
    public static readonly IShopService ShopService = new ShopService();
    public static readonly IPageMediator PageMediator = new PageMediator();
}