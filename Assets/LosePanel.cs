using UnityEngine;

public class LosePanel : MonoBehaviour
{
    public Timer timer;

    private void Start()
    {
        timer.timerIsStoped += OpenLosePanel;
        gameObject.SetActive(false);

    }

    private void OpenLosePanel()
    {
        Debug.LogError("Проиграл");
        gameObject.SetActive(true);
    }
}
