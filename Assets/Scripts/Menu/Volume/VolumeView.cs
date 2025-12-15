using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class VolumeView : MonoBehaviour , IVolumeView
{
    [SerializeField] private Slider seSlider;
    [SerializeField] private Slider bgmSlider;

    public IObservable<float> OnChangeSeVolume
        => seSlider.OnValueChangedAsObservable();

    public IObservable<float> OnChangeBgmVolume
        => seSlider.OnValueChangedAsObservable();

    public void SetSeSlider(float value)
    {
        seSlider.SetValueWithoutNotify(value);//表示だけ更新
    }
    
    public void SetBgmSlider(float value)
    {
        bgmSlider.SetValueWithoutNotify(value);
    }
}
