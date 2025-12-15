using System;

public interface IVolumeView
{
    IObservable<float> OnChangeSeVolume { get; }
    IObservable<float> OnChangeBgmVolume { get; }

    void SetSeSlider(float volume);
    void SetBgmSlider(float volume);
}
