using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // �������� �����������
    private Rigidbody rb;         // ������ �� ��������� Rigidbody

    // ����� Start ���������� ��� �������
    void Start()
    {
        // �������� ������ �� ��������� Rigidbody
        rb = GetComponent<Rigidbody>();

        // ������������ �������� �� X � Z, �� �� ������������ �������� �� Y
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // FixedUpdate ���������� �� ������ ������������� ���������� ������
    void FixedUpdate()
    {
        // �������� ���� �� ��� X (����-�����) � ��� Z (������-�����)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // ������� ������ ��� �����������
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // ���������� ������� � �������������� ������
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
