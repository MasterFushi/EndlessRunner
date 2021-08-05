using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set : MonoBehaviour
{
    public List<Obstacle> obstacles = new List<Obstacle>();
    public GameObject obstaclePrefab;

    public int speed;

    private int numObstacles;

    private void Awake()
    {
        numObstacles = Random.Range(1, 4);
        transform.position = new Vector3(0, 0, 150);

        for (int i = 0; i < numObstacles; i++) {
            GameObject ob = Instantiate(obstaclePrefab, transform) as GameObject;
            obstacles.Add(ob.GetComponent<Obstacle>());
        }
    }

    private void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }
}
