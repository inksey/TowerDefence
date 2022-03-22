using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{

    [HideInInspector]

    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;
    public float speed = 1.0f;


    void Start()
    {
        lastWaypointSwitchTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = waypoints [currentWaypoint].transform.position;
        Vector3 endPosition = waypoints [currentWaypoint + 1].transform.position;

        float pathLength = Vector3.Distance (startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        gameObject.transform.position = Vector2.Lerp (startPosition, endPosition, currentTimeOnPath / totalTimeForPath);

        if (gameObject.transform.position.Equals(endPosition)) 
            {
                if (currentWaypoint < waypoints.Length - 2)
                    {
                        currentWaypoint++;
                        lastWaypointSwitchTime = Time.time;
                        RotateIntoMoveDirection();
                    }
                else
                    {
                        Destroy(gameObject);

                        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                        AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                        GameManagerBehaviour gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehaviour>();
                        gameManager.Health -= 1;
                    }
            }
    }

    private void RotateIntoMoveDirection()
        {
            Vector3 newStartPosition = waypoints [currentWaypoint].transform.position;
            Vector3 newEndPosition = waypoints [currentWaypoint + 1].transform.position;
            Vector3 newDirection = (newEndPosition - newStartPosition);

            float x = newDirection.x;
            float y = newDirection.y;
            float rotationAngle = Mathf.Atan2 (y, x) * 180 / Mathf.PI;

            GameObject sprite = gameObject.transform.Find("Sprite").gameObject;
            sprite.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
        }


}
