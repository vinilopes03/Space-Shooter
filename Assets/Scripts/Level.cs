using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delay = 2f;
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameSession>().resetGame();
    }

    public void LoadGameOver()
    {
        StartCoroutine(waitAndLoad());
    }

    IEnumerator waitAndLoad()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
