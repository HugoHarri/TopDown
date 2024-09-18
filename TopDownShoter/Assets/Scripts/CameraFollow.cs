using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Цель, за которой следует камера
    public float smoothSpeed = 0.700f; // Скорость сглаживания движения камеры
    public Vector3 offset; // Смещение камеры относительно цели

    void LateUpdate()
    {
        // Определяем позицию камеры с учетом смещения
        Vector3 desiredPosition = target.position + offset;
        // Плавное движение камеры
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Камера смотрит на цель
        transform.LookAt(target);
    }
}
