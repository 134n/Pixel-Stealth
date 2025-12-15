using KanKikuchi.AudioManager;
using UnityEngine;

public class MenuButtonService
{
    public void OpenPanel()
    {
        SEManager.Instance.Play(SEPath.TAP1);
        //Panel.SetActive(true);
    }

    public void ClosePanel(GameObject Panel)
    {
        SEManager.Instance.Play(SEPath.TAP1);
        //Panel.SetActive(false);
    }
}
