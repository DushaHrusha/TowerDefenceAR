using System.Collections;
using UnityEngine;

public class Titan : MonoBehaviour
{
    public Transform towerTransform; // Ссылка на трансформ башни
    public float moveSpeed = 2f; // Скорость движения врага
    private Rigidbody rb;
    public Animator animator;
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
        animator.SetBool("Attack", true);
        StartCoroutine(TimeAttak());
    }

    IEnumerator TimeAttak()
    {
        while(true)
        {
            towerDamage.TakeDamage(5);
            yield return new WaitForSeconds(1.17f);
        }
        
    }


}