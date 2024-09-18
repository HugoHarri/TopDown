using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    public Camera mainCamera; // ������, ����� ������� �� ����� ��������
    public float rotationSpeed = 100f; // �������� �������� �������

    void Update()
    {
        // �������� ������� ������� � ������� �����������
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Vector3.Distance(mainCamera.transform.position, transform.position);

        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        worldMousePosition.y = transform.position.y;

        // ��������� ����������� �� ������� � ������� ����
        Vector3 direction = worldMousePosition - transform.position;
        direction.y = 0; // ���������� ��������� �� Y ��� ����������� ��������

        // ���������, ��� ����������� �� �������
        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
