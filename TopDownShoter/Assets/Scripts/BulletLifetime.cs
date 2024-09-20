using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLifetime : MonoBehaviour
{
    public float lifetime = 60f; // ����� ����� ���� � ��������

    void Start()
    {
        // ��������� ����� DestroyBullet ����� �������� �����
        Destroy(gameObject, lifetime);
    }
}
