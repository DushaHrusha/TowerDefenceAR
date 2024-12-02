using DilmerGames.Core.Singletons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOptions : Singleton<GameOptions>
{
    private bool meshVisibilityOn = true;

    [SerializeField]

    public void ToggleMeshVisibility(Button button)
    {

        meshVisibilityOn = !meshVisibilityOn;
        
        button.GetComponentInChildren<TextMeshProUGUI>().text = meshVisibilityOn ? 
            "MESHING ON" : "MESHING OFF";
    }
}
