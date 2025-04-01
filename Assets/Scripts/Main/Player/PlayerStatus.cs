using UniRx;

public class PlayerStatus
{
    public ReactiveProperty<int> Key { get; set; } = new ReactiveProperty<int>(0);
}
