using System.Threading.Tasks;
using Avalonia.Media.Imaging;

namespace EvoComTest.ViewModels.Items;

public record ShopItemViewModel(Task<Bitmap?> Image, int Count, string Label, decimal Price);