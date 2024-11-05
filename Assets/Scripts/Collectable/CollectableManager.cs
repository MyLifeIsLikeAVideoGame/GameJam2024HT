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

    private void Update()
    {
        pointDisplay.text = "Coins: " + pointsCollected;
    }
}
