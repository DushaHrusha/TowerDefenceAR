using System.Collections;
using UnityEngine;

public class СargoAirship : MonoBehaviour
{
    public Transform towerTransform; // Ссылка на трансформ башни
    public float moveSpeed = 2f; // Скорость движения врага
    public ParticleSystem particleSystem;
    private Rigidbody rb;
    private bool isWalking = true;
    private EnemyHealth towerDamage;
    private void Start()
    {
        towerDamage = towerTransform.GetComponent<EnemyHealth>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(isWalking == true)
            MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        // Вычисляем направление к башне
        Vector3 direction = (towerTransform.position - transform.position).normalized;

        // Применяем силу к Rigidbody, чтобы двигать врага
        transform.localPosition += direction * moveSpeed * Time.deltaTime;
        
        // Опционально: вращаем врага в сторону игрока
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.localRotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * moveSpeed);
    }

    public void Attak()
    {
        isWalking = false;
        particleSystem.Play();
        Destroy(this.gameObject, 1.5f);
        towerDamage.TakeDamage(10);

    }
   
}