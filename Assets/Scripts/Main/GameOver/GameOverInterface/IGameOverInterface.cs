using System;
using UniRx;

public interface IGameOverInterface 
{
    public void Hide();
}
public interface IHitStream
{
    IObservable<Unit> HitPlayer { get; }
}
