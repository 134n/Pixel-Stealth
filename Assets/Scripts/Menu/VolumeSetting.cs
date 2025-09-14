using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using UniRx;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] Button volume;

    [SerializeField] GameObject volumeSetting;

    [SerializeField] Button buck;

    public void Start()
    {
        volume.OnClickAsObservable()
            .Subscribe(_ => volumeSetting.SetActive(true))
            .AddTo(this);

        buck.OnClickAsObservable()
            .Subscribe(_ => volumeSetting.SetActive(false))
            .AddTo(this);
    }
}
