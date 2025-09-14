using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    [SerializeField] Button message;

    [SerializeField] GameObject messagePanel;

    [SerializeField] Button buck;

    public void Start()
    {
        message.OnClickAsObservable()
            .Subscribe(_ => messagePanel.SetActive(true))
            .AddTo(this);

        buck.OnClickAsObservable()
            .Subscribe(_ => messagePanel.SetActive(false))
            .AddTo(this);
    }
}
