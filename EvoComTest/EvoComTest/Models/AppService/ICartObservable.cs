namespace EvoComTest.Models.AppService;

public interface ICartObservable
{
    void AddObserver(ICartObserver cartObserver);
    
    void RemoveObserver(ICartObserver cartObserver);

    void Update();
}