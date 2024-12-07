using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth; // Максимальное здоровье врага
    public float currentHealth; // Текущее здоровье врага
    public Animator animator;
    public Slider healthSlider; // Ссылка на UI Slider
    public static int countKillEnemy = 0;
    public GameObject LosePanel;
    void Start()
    {
        currentHealth = maxHealth; // Устанавливаем текущее здоровье на максимум
        UpdateHealthSlider(); // Обновляем слайдер
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Уменьшаем здоровье на величину урона
        if (currentHealth < 0)
        {
            if(transform.tag == "Tower")
            {
                
                LosePanel.SetActive(true);
            }
            else
            {
                currentHealth = 0; // Не допускаем отрицательного здоровья
                animator.SetBool("IsDeath", true);
                Invoke("KillEnemy",3f);
            }
            
        }
        UpdateHealthSlider(); // Обновляем слайдер
    }

    private void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth; // Обновляем значение слайдера
        }
    }


    private void KillEnemy()
    {
        countKillEnemy++;
        Destroy(this.gameObject);
    }    
}