using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public List<GameObject> obstacleTypes;

    private readonly Vector3[] dirs = {new Vector3(-5,0,0),new Vector3(0,0,0),new Vector3(5,0,0)};

    void Awake()
    {
        //Generating Random obstacle from pool
        int randInd = Random.Range(0, obstacleTypes.Count);
        GameObject clone = Instantiate(obstacleTypes[randInd], transform.position, Quaternion.identity, transform);

        //Setting location
        transform.localPosition = dirs[Random.Range(0, 3)];
    }
}
