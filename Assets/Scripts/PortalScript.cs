using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public string sceneName;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("SceneTransitioner").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            StartCoroutine(SceneTransition());
        }
    }

    IEnumerator SceneTransition()
    {
        anim.SetTrigger("fade");
        yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(sceneName);
    }
}
