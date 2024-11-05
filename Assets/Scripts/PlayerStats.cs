using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerStats : Entity
{
    public int power, speed, maxHealth;
    float powerMultiplier, speedMultiplier, fireRateMultiplier;
    public float fireRate;

    public Image[] hearts;
    public Sprite fullHeart, emptyHeart;

   [HideInInspector] public float currentXp;
    public float level, maxXp;
    float overflowXp;
    public Slider xpBar;
    public TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
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
        levelText.text = "LV: " + level.ToString();

    }
}
