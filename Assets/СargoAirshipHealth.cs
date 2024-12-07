using UnityEngine;
using UnityEngine.UI;

public class СargoAirshipHealth : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public float maxHealth; // Максимальное здоровье врага
    private float currentHealth; // Текущее здоровье врага
    public Slider healthSlider; // Ссылка на UI Slider

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
            currentHealth = 0; // Не допускаем отрицательного здоровья
            particleSystem.Play();
            Invoke("KillEnemy",1.5f);
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
         Destroy(this.gameObject);
    }    
}