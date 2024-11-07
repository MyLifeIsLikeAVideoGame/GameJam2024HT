using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableManager : MonoBehaviour
{
    public int keysCollected = 0;
    public int pointsCollected = 0;
    public TextMeshProUGUI pointDisplay;
    public IntValue keysSave, pointsSave;
    private void Start()
    {
        keysCollected = keysSave.value;
        pointsCollected = pointsSave.value;
    }

    private void Update()
    {
        pointDisplay.text = ": " + pointsCollected;
        keysSave.value = keysCollected;
        pointsSave.value = pointsCollected;
    }
}
