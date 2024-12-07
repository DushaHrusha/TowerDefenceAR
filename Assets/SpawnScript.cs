using System.Collections;
using UnityEngine;
using System;
public class SpawnScript : MonoBehaviour
{
    public Transform[] spawnPointer;
    public GameObject[] enemy;
    public GameObject WinPanel;
    public Transform transformTower;

    void Start()
    {
        StartGame() ;
    }
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
        var random = new System.Random();
        int i = 6;
        while(i > 0)
        {
            for (int j = 0; j < spawnPointer.Length; j++)
            {
                yield return new WaitForSeconds(random.Next(3,7));
                GameObject init = Instantiate(enemy[random.Next(0,3)], spawnPointer[j].position, Quaternion.identity);
                try
                {
                    init.GetComponent<Titan>().towerTransform = transformTower;
                }
                catch (Exception ex)
                {
                    Debug.Log("нет такого компанента");
                }
                try
                {
                    init.GetComponent<СargoAirship>().towerTransform = transformTower;
                }
                catch (Exception ex)
                {
                    Debug.Log("нет такого компанента");
                }
                try
                {
                    init.GetComponentInChildren<Titan>().towerTransform = transformTower;
                }
                catch (Exception ex)
                {
                    Debug.Log("нет такого компанента");
                }

            }
            i--;
        }
        
        WinPanel.SetActive(true);
        
        
    }
}
