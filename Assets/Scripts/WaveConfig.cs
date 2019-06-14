using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave")]

public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float spawnsDelay = 0.4f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject getEnemyPrefab()
    {
        return enemyPrefab;
    }
    public List<Transform> getWayPoints()
    {
        var waveWayPoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;
    }
    public float getSpawnsDelay()
    {
        return spawnsDelay;
    }
    public int getNumberOfEnemies()
    {
        return numberOfEnemies;
    }
    public float getMoveSpeed()
    {
        return moveSpeed;
    }

}
