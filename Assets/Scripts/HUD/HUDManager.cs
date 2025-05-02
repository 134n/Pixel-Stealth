using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] public Text stageText;

    [SerializeField] public Text timerText;
    
    [SerializeField] public Text objectiveText;

    [SerializeField] public float limitTime;

    /// <summary>
    /// アイテムUI
    /// </summary>
    [SerializeField] public List<Image> itemSlots;

    [SerializeField] public Sprite emptySprite;

    [SerializeField] public Sprite collectedSprite;
    // [SerializeField] public Text remainingText;

    /// <summary>
    /// アイテム取得時の通知Subject
    /// </summary>
    private readonly Subject<Unit> onItemCollected = new Subject<Unit>();
    
    public Subject<Unit> OnItemCollected => onItemCollected;
}
