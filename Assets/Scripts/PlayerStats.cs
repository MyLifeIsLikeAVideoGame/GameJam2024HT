using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int power, speed, currentHealth, maxHealth, fireRate;
    float powerMultiplier, speedMultiplier, fireRateMultiplier;

    public Image[] hearts;
    public Sprite fullHeart, emptyHeart;

    float currentXp;
    public float level, maxXp;
    float overflowXp;
    public Slider xpBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;

            }
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if (currentXp >= maxXp)
        {
            level++;
            overflowXp = currentXp - maxXp;
            currentXp = overflowXp;
            maxXp *= 1.1f;
        }
        xpBar.value = currentXp;
        xpBar.maxValue = maxXp;

    }
}
