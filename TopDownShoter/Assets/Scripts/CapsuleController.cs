using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    public Camera mainCamera; // Камера, через которую мы будем смотреть

    void Update()
    {
        // Получаем позицию курсора в мировых координатах
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(mainCamera.transform.position.z); // Задаем Z-координату для расчета

        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Находим направление от капсулы к позиции мыши
        Vector3 direction = new Vector3(worldMousePosition.x - transform.position.x,
                                         worldMousePosition.y - transform.position.y,
                                         worldMousePosition.z - transform.position.z);

        // Проверяем, что направление не нулевое
        if (direction != Vector3.zero)
        {
            // Находим угол поворота вокруг оси Z
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // Создаем поворот вокруг оси Z
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);

            // Плавное вращение
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}

