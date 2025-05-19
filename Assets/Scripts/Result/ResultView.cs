using UnityEngine;
using UnityEngine.UI;

public class ResultView : MonoBehaviour
{
    [SerializeField] private Button retry;

    [SerializeField] private Button toTitle;

    [SerializeField] private Button ranking;

    public Button Retry => retry;

    public Button ToTitle => toTitle;

    public Button Ranking => ranking;

    public Text ResultTimeText;

    public Text ResultRankText;
}
