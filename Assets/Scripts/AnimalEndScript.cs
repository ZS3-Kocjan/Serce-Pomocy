using System.Collections;
using Unity.VisualScripting;
using UnityEngine.ParticleSystemJobs;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalEndScript : MonoBehaviour
{
    private int playersNear=0;
    private bool levelEnded=false;
    public ScoreManager SM;
    void OnTriggerEnter2D(Collider2D collision)
    {
        playersNear++;
        Debug.Log(playersNear);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        playersNear--;
        Debug.Log(playersNear);
    }

    void Update()
    {
        if (playersNear == 2 && levelEnded==false)
        {
            if(SM.levelScore == 6)
            {
                levelEnded = true;
            }
            StartCoroutine(levelSummary());
        }
    }

    IEnumerator levelSummary()
    {
        var Hearts = GetComponentsInChildren<SpriteRenderer>();
        int i = 0;
        Debug.Log("starting");
        foreach(SpriteRenderer heart in Hearts)
        {   
            Debug.Log(i);
            Debug.Log(SM.levelScore);
            Debug.Log(i <= SM.levelScore);
            Debug.Log(heart.name);
            if (i <= SM.levelScore && i!=0)
            {
                Debug.Log("huh");
                heart.color = Color.white;
                heart.GetComponent<ParticleSystem>().Play();
                yield return new WaitForSeconds(1);
            }
            i++;
        }
        Debug.Log("Koniec");
        if (levelEnded == true)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
