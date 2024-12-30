using UniRx;
using UniRx.Triggers;
using VContainer;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class PlayerPickItemController : MonoBehaviour
{
    private ItemKey itemKey;
    private ItemMatatabi itemMata;

    [Inject] public void Inject(ItemKey itemKey) => this.itemKey = itemKey;

    [Inject] public void Inject(ItemMatatabi itemMata) => this.itemMata = itemMata;

    private const string Key = "ItemKey";

    private const string Mata = "ItemMata";

    private void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Where(other => other.gameObject.name == Key)
            .Subscribe(other => itemKey.Pick())
            .AddTo(this);

        this.OnTriggerEnter2DAsObservable()
            .Where(other => other.gameObject.name == Mata)
            .Subscribe(other => itemMata.Pick())
            .AddTo(this);
    }
}
