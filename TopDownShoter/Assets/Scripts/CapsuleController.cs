using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    public Camera mainCamera; // Камера, через которую мы будем смотреть
    public float rotationSpeed = 500f; // Скорость вращения капсулы

    void Update()
    {
        // Получаем позицию курсора в мировых координатах
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(mainCamera.transform.position.z); // Задаем Z-координату для расчета

        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Находим направление от капсулы к позиции мыши
        Vector3 direction = new Vector3(worldMousePosition.x - transform.position.x,
                                         0, // Игнорируем изменения по оси Y для правильного вращения
                                         worldMousePosition.z - transform.position.z);

        // Проверяем, что направление не нулевое
        if (direction.magnitude > 0.1f)
        {
            // Находим угол поворота относительно оси Y
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // Создаем поворот только вокруг оси Y
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);

            // Плавное вращение с использованием RotateTowards
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
