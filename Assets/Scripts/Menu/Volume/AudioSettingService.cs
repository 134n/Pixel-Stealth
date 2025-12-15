using KanKikuchi.AudioManager;
using UnityEngine;

public class AudioSettingService
{
    //保存を追加する
    private const float DefaultSeVolume = 0.5f;
    private const float DefaultBgmVolume = 0.5f;

    public void ApplyAll()
    {
        ApplySeVolume();
        ApplyBgmVolume();
    }

    private void ApplySeVolume()
    {
        float volume = GetSeVolume();               // 保存値 or 初期値(0.5)
        SEManager.Instance.ChangeBaseVolume(volume);
    }

    private void ApplyBgmVolume()
    {
        float volume = GetBgmVolume();              // 保存値 or 初期値(0.5)
        BGMManager.Instance.ChangeBaseVolume(volume);
    }

    public float GetSeVolume()//defult　SeVolumeをDefaultSeVolumeにする
    {
        return PlayerPrefs.GetFloat("SeVolume", DefaultSeVolume);
    }

    public float GetBgmVolume()//defult
    {
        return PlayerPrefs.GetFloat("BgmVolume", DefaultBgmVolume);
    }

    public void SetSeVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        PlayerPrefs.SetFloat("SeVolume", volume);
        SEManager.Instance.ChangeBaseVolume(volume);
    }

    public void SetBgmVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        PlayerPrefs.SetFloat("BgmVolume", volume);
        BGMManager.Instance.ChangeBaseVolume(volume);
    }
}
