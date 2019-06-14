using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI text;
    GameSession game;

    // Start is called before the first frame update
    void Start()
    {

        text = GetComponent<TextMeshProUGUI>();
        game = FindObjectOfType<GameSession>();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();

    }

    private void UpdateScore()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            text.text = "SCORE " + game.getScore().ToString();
            Debug.Log(game.getScore().ToString());
        }
        else
        {
            text.text = game.getScore().ToString();
        }
    }
}
