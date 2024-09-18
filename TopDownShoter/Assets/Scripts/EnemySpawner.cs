using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����
    public float spawnInterval = 5f; // �������� ������ ������
    public float spawnRadius = 20f; // ������ ������ ������ ������
    private Transform player; // ������ �� ������

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // ������� ������
        StartCoroutine(SpawnEnemies()); // ��������� �������� ������ ������
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy(); // ������� ����� ������ ��������� ������
        }
    }

    private void SpawnEnemy()
    {
        // ������� ����� � ��������� ����� �� ��������� ���������
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // ���������� ��������� ����� �� ���������� ������ ������
        Vector3 spawnDirection = Random.insideUnitSphere.normalized;
        spawnDirection.y = 0; // �������� ������ ��� 3D
        Vector3 spawnPosition = player.position + spawnDirection * spawnRadius;
        return spawnPosition;
    }
}