using UnityEngine;

public class Titan : MonoBehaviour
{
    public Transform towerTransform; // Ссылка на трансформ башни
    public float moveSpeed = 2f; // Скорость движения врага
    private Rigidbody rb;
    public Animator animator;
    private bool isWalking = true;

    private void Start()
    {
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
        transform.position += direction * moveSpeed * Time.deltaTime;
        
        // Опционально: вращаем врага в сторону игрока
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * moveSpeed);
    }

    public void Attak()
    {
        isWalking = false;
        animator.SetBool("Attack", true);
        
    }

}