using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpdateEjs : MonoBehaviour
{
     public GameObject Ejs;
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
        Ejs.SetActive(true);
        enemyHealth.maxHealth += 50;
        enemyHealth.currentHealth = enemyHealth.maxHealth;
        button.enabled = true;

    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(25f);
        button.interactable = true;
    }
}
