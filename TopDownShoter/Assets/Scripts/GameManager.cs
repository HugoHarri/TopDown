using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void ReloadScene()
    {
        // Получаем текущую активную сцену
        Scene currentScene = SceneManager.GetActiveScene();
        // Перезагружаем сцену
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
