using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttaack : MonoBehaviour
{
    public GameObject projectilePrefab; // Префаб снаряда
    public Transform firePointOne; // Точка, из которой будут выходить снаряды
    public Transform firePointTwo; // Точка, из которой будут выходить снаряды
    public float fireRate = 2f; // Интервал между выстрелами
    public int damage = 3; // Урон от снаряда
    public GameObject explosionEffect; // Префаб эффекта взрыва
    public float projectileSpeed = 20f; // Скорость снаряда

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            FireProjectile();
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void FireProjectile()
    {
        GameObject projectileOne = Instantiate(projectilePrefab, firePointOne.position, firePointOne.rotation);
        GameObject projectileTwo = Instantiate(projectilePrefab, firePointTwo.position, firePointTwo.rotation);

        Rigidbody rb1 = projectileOne.GetComponent<Rigidbody>();
        Rigidbody rb2 = projectileTwo.GetComponent<Rigidbody>();
        
        rb1.velocity = firePointOne.forward * projectileSpeed;
        rb2.velocity = firePointTwo.forward * projectileSpeed;
    }
}
