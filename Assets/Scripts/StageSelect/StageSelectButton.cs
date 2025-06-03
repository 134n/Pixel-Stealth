using UnityEngine;
using UnityEngine.UI;

public class StageSelectButton : MonoBehaviour
{
    [SerializeField] private Button[] stages;
    public Button[] Stages => stages;

    [SerializeField] private Button buck;
    public Button Buck => buck;
}
