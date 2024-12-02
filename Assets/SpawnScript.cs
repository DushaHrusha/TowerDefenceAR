using System.Collections;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform[] spawnPointer;
    public GameObject[] ball;

    public void StartGame()
    {
        StartCoroutine(StartSpawnig());
    }

    public void StopGame()
    {
        StopAllCoroutines();
    }
    
    IEnumerator StartSpawnig()
    {
        for (int j = 0; j < 4; j++)
        {
            yield return new WaitForSeconds(3f);
            for (int i = 0; i < 3; i++)
            {
                Instantiate(ball[i], spawnPointer[i].position, Quaternion.identity);
            }
        }
        
    }
}
