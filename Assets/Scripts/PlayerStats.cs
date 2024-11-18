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
    public int level;
     public float maxXp;
    float overflowXp;
    public Slider xpBar;
    public TextMeshProUGUI levelText;
    public int statPoints;
    public int pointsInFireRate;

    public IntValue powerSave, speedSave, healthSave, levelSave, statPointsSave, pointsInFireRateSave;
    public FloatValue fireRateSave, maxXpSave, overFlowXpSave, xpSave;
    public CameraShake cam;

    // Start is called before the first frame update
    void Start()
    {
        power = powerSave.value;
        speed = speedSave.value;
        health = healthSave.value;
        level = levelSave.value;
        maxXp = maxXpSave.value;
        statPoints = statPointsSave.value;
        pointsInFireRate = pointsInFireRateSave.value;
        fireRate = fireRateSave.value;
        overflowXp = overFlowXpSave.value;
        currentXp = xpSave.value;
        normalMaterial = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

    }

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
            statPoints++;
            overflowXp = currentXp - maxXp;
            currentXp = overflowXp;
            maxXp *= 1.1f;
        }
        powerSave.value = power;
        speedSave.value = speed;
        healthSave.value = health;
        levelSave.value = level;
        maxXpSave.value = maxXp;
        statPointsSave.value = statPoints;
        pointsInFireRateSave.value = pointsInFireRate;
        fireRateSave.value = fireRate;
        overFlowXpSave.value = overflowXp       ;
        xpSave.value = currentXp;

        xpBar.value = currentXp;
        xpBar.maxValue = maxXp;
        health = Mathf.Clamp(health, 0, maxHealth);
        levelText.text = level.ToString();

    }

    public void IncreasePower()
    {
        if (statPoints > 0)
        {
            power++;
            statPoints--;
        }
    }
    public void IncreaseSpeed()
    {
        if (statPoints > 0)
        {
            speed++;
            statPoints--;
        }
    }
    public void IncreaseFireRate()
    {
        if (statPoints > 0)
        {
            fireRate *= 0.95f;
            statPoints--;
            pointsInFireRate++;
        }
    }
    
}
