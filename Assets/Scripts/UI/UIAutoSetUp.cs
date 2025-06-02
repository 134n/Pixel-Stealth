using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIAutoSetUp : MonoBehaviour
{
    public void Awake()
    {
        Button[] buttons = FindObjectsOfType<Button>();

        foreach (var bts in buttons)
        {
            bts.AddComponent<UIButtonHighlight>();
        }
    }
}
