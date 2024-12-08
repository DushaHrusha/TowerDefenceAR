using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    /*
    public float speed = 10f; // Скорость снаряда
    public GameObject explosionEffect; // Префаб эффекта взрыва
    private int damage; // Урон от снаряда

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void SetDamage(int damageAmount)
    {
        damage = damageAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем, попал ли снаряд в игрока
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Наносим урон игроку
            }

            Instantiate(explosionEffect, transform.position, transform.rotation); // Воспроизводим эффект взрыва
            Destroy(gameObject); // Уничтожаем снаряд
        }
        else if (other.CompareTag("Wall")) // Если снаряд попадает в стену
        {
            Instantiate(explosionEffect, transform.position, transform.rotation); // Воспроизводим эффект взрыва
            Destroy(gameObject); // Уничтожаем снаряд
        }
    }
    */
}
