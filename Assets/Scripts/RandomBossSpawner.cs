using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBossSpawner : MonoBehaviour
{
    public GameObject[] bosses;
    int rand;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, bosses.Length);
        Instantiate(bosses[rand]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
