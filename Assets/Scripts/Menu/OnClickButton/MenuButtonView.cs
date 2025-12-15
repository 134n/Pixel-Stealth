using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonView : MonoBehaviour, IMenuButtonView
{
    [SerializeField] private GameObject messagePanel;
    public GameObject MessagePanel => messagePanel;

    [SerializeField] private GameObject volumePanel;
    public GameObject VolumePanel => volumePanel;

    
    [SerializeField] private Button volumeButton;
    
    [SerializeField] private Button messageButton;

    [SerializeField] private Button closeVolumeButton;
    
    [SerializeField] private Button closeMessageButton;

    public IObservable<Unit> OpenMessagePanel
        => messageButton.OnClickAsObservable();

    public IObservable<Unit> CloseMessagePanel
        => closeMessageButton.OnClickAsObservable();

    public IObservable<Unit> OpenVolumePanel
        => volumeButton.OnClickAsObservable();

    public IObservable<Unit> CloseVolumePanel
        => closeVolumeButton.OnClickAsObservable();

    public void ShowMessagePanel() => messagePanel.SetActive(true);
    public void HideMessagePanel() => messagePanel.SetActive(false);

    public void ShowVolumePanel()  => volumePanel.SetActive(true);
    public void HideVolumePanel()  => volumePanel.SetActive(false);
}
