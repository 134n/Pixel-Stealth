using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private GameObject gameOverObj;

    public GameObject GameOverObj => gameOverObj;

    [SerializeField] Button resultButton;

    public Button ResultButton => resultButton;
}
