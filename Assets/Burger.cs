using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Burger : MonoBehaviour
{
    public GameObject WinPanel;
    public GameObject EndPanel;

    public Image[] spritesBurger;
    public int i = 5;
    
    void Start()
    {
        WinPanel.SetActive(false);
        EndPanel.SetActive(false) ;
    }
    
    public void GetPanel()
    {
        i--;
        spritesBurger[i].color = new Color(255, 255, 255, 255);
        if (i <= 0)
        {
            EndPanel.SetActive(true) ;
        }
        StartCoroutine(panelTimer());

    }

    IEnumerator panelTimer()
    {
        WinPanel.SetActive(true);
        yield return new WaitForSeconds(3);
        WinPanel.SetActive(false);
        StopCoroutine(panelTimer());
    }
    
}
