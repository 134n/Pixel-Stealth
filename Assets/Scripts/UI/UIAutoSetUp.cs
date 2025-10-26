using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIAutoSetUp : MonoBehaviour
{
    public void Awake()
    {
        Button[] buttons = FindObjectsByType<Button>(FindObjectsInactive.Include,FindObjectsSortMode.None);

        foreach (var bts in buttons)
        {
            bts.AddComponent<UIButtonHighlight>();
        }
    }
}
