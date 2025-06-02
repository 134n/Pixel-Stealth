using UnityEngine;
using UnityEngine.UI;

public class TitleView : MonoBehaviour
{
    [SerializeField] private Button stageSelect;

    public Button StageSelect => stageSelect;

    [SerializeField] private Button menu;

    public Button Menu => menu;
}
