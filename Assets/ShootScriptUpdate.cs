using UnityEngine;

public class ShootScriptUpdate : MonoBehaviour
{
    public Camera arCamera;
    public Transform towerGunTransform;
    public Transform towerTransform;
    public float rotationSpeed;
    public float maxVerticalAngle; // Максимальный угол вертикального вращения
    public float minVerticalAngle; // Минимальный угол вертикального вращения

    private float currentVerticalAngle = 0f; // Текущий угол вертикального вращения
    public GameObject projectilePrefab; // Префаб снаряда
    public Transform firePointOne; // Точка, откуда будет происходить выстрел
    public Transform firePointTwo; // Точка, откуда будет происходить выстрел
    public float projectileSpeed; // Скорость снаряда

    private void Update()
    {
        MoveGun();
        if (Input.GetMouseButtonDown(0)) // Проверяем, нажата ли левая кнопка мыши
        {
            Shoot();
        }
        
    }
    public void MoveGun()
    {
        // Получаем координаты центра экрана
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

        // Преобразуем экранные координаты в мировые
        Ray ray = arCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        // Если луч попадает в объект, получаем точку, на которую указывает камера
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetDirection = hit.point - towerTransform.position;
            var NewTargetDirection = targetDirection;
            NewTargetDirection.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(-NewTargetDirection);

            towerTransform.rotation = Quaternion.Lerp(towerTransform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            Vector3 targetPoint = hit.point; // Получаем точку пересечения
            Vector3 direction = targetPoint - transform.position; // Вычисляем направление к цели

           
            float targetVerticalAngle = Mathf.Atan2(direction.y, direction.magnitude) * Mathf.Rad2Deg;
            currentVerticalAngle = Mathf.Clamp(targetVerticalAngle, minVerticalAngle, maxVerticalAngle);

            transform.localEulerAngles = new Vector3(currentVerticalAngle, transform.localEulerAngles.y, 0);
        }
    }

    public void Shoot()
    {
        // Создаем снаряд
        GameObject projectileOne = Instantiate(projectilePrefab, firePointOne.position, firePointOne.rotation);
        GameObject projectileTwo = Instantiate(projectilePrefab, firePointTwo.position, firePointTwo.rotation);
        
        // Получаем компонент Rigidbody у снаряда
        Rigidbody rbOne = projectileOne.GetComponent<Rigidbody>();
        Rigidbody rbTwo = projectileTwo.GetComponent<Rigidbody>();
        
        // Применяем силу к снаряду для его движения
        rbOne.velocity = firePointOne.forward * projectileSpeed;
        rbTwo.velocity = firePointTwo.forward * projectileSpeed;
    } 
}
