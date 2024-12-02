using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{

    public void RestartVrGame()
    {
        SceneManager.LoadScene(0);
    }
}
