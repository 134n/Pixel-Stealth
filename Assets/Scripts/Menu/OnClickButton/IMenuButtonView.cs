using System;
using UniRx;
using UnityEngine;

public interface IMenuButtonView
{
    void ShowMessagePanel();
    void HideMessagePanel();

    void ShowVolumePanel();
    void HideVolumePanel();
    
    IObservable<Unit> OpenMessagePanel { get; }
    IObservable<Unit> CloseMessagePanel { get; }

    IObservable<Unit> OpenVolumePanel{get;}
    IObservable<Unit> CloseVolumePanel{get;}
}