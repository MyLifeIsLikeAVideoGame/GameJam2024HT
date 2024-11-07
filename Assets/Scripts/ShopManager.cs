using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseBulletsShot(int cost)
    {
        if (player.GetComponent<CollectableManager>().pointsCollected >= cost)
        {
            player.GetComponentInChildren<Gun>().numberOfbullets++;
            player.GetComponent<CollectableManager>().pointsCollected -= cost;
        }
    }
    public void DecreaseSpread(int cost)
    {
        if (player.GetComponent<CollectableManager>().pointsCollected >= cost)
        {
            player.GetComponentInChildren<Gun>().bulletSpread *= 0.9f;
            player.GetComponent<CollectableManager>().pointsCollected -= cost;
        }
    }
    public void NextScene()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
