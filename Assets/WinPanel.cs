using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    public Figure figure;

    private void Start() 
    {
        figure.figureIsDone += OpenWinPanel;
        gameObject.SetActive(false);
    }


    private void OpenWinPanel()
    {
        
        gameObject.SetActive(true);
    }
}
