using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public float spawnInterval = 5f; // Интервал спавна врагов
    public float spawnRadius = 20f; // Радиус спавна вокруг игрока
    private Transform player; // Ссылка на игрока

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Находим игрока
        StartCoroutine(SpawnEnemies()); // Запускаем корутину спавна врагов
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy(); // Спавним врага каждые несколько секунд
        }
    }

    private void SpawnEnemy()
    {
        // Спавним врага в случайной точке за пределами видимости
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Генерируем случайную точку на окружности вокруг игрока
        Vector3 spawnDirection = Random.insideUnitSphere.normalized;
        spawnDirection.y = 0; // Обнуляем высоту для 3D
        Vector3 spawnPosition = player.position + spawnDirection * spawnRadius;
        return spawnPosition;
    }
}