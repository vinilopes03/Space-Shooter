using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveconfig;
    List<Transform> wayPoints;


    int wayPointsIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        wayPoints = waveconfig.getWayPoints();
        transform.position = wayPoints[wayPointsIndex].transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    public void setWaveConfig(WaveConfig waveconfig)
    {
        this.waveconfig = waveconfig;
    }

    private void Move()
    {
        if (wayPointsIndex <= wayPoints.Count - 1)
        {


            var targetPosition = wayPoints[wayPointsIndex].transform.position;
            var moveDelta = waveconfig.getMoveSpeed() * Time.deltaTime;



            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveDelta);

            if (transform.position == targetPosition)
            {
                wayPointsIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
