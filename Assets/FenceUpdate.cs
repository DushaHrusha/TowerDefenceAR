using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FenceUpdate : MonoBehaviour
{
    public GameObject Fence;
    public EnemyHealth enemyHealth;
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = false;
        StartCoroutine(enumerator());
    }
    public void UpdateFence()
    {
        Fence.SetActive(true);
        enemyHealth.maxHealth += 50;
        enemyHealth.currentHealth = enemyHealth.maxHealth;
        button.enabled = true;
    }

    IEnumerator enumerator()
    {
        Debug.Log("sdffsdfffffffffffffffffffffffffffffffffff");
        yield return new WaitForSeconds(5f);
        button.interactable = true;
        Debug.Log("________________________________________");
        yield return new WaitForSeconds(1f);
    }
}
