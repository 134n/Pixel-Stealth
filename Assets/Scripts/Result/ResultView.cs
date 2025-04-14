using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultView : MonoBehaviour
{
    [SerializeField] private Button retry;

    [SerializeField] private Button toTitle;

    public Button Retry => retry;

    public Button ToTitle => toTitle;
}
