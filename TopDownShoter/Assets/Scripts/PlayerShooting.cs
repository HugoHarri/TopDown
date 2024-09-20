using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ����
    public Transform firePoint;     // ����� ��������
    public float bulletSpeed = 20f; // �������� ������ ����

    private bool isShooting = false; // ���� ��� �������� �������������� ��������

    void Update()
    {
        // ���������, ������ �� ����� ������ ����
        if (Input.GetMouseButton(0))
        {
            if (!isShooting)
            {
                isShooting = true;
                InvokeRepeating("Shoot", 0f, 0.1f); // �������� �������������� ��������
            }
        }
        else
        {
            if (isShooting)
            {
                isShooting = false;
                CancelInvoke("Shoot"); // ������������� �������������� ��������
            }
        }
    }

    void Shoot()
    {
        // ������� ���� � ������� ����� �������� � ������������ �������
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // ���� � ���� ���� Rigidbody, ������ �� ��������� ��������
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
    }
}
