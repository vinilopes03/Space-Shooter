using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] int score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        setSingleton();   
    }
    
    private void setSingleton()
    {
        if(FindObjectsOfType<GameSession>().Length > 1)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int getScore()
    {
        return score;
    }

    public void addScore(int points)
    {
        score += points;
    }
    public void resetGame()
    {
        DestroyImmediate(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
