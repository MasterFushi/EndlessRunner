using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public float speed, lerpSpeed;
    public int nextIndex, currIndex;
    public Vector3 desiredPosition;

    private Vector2 initialPosition;

    private Vector3[] directions = { new Vector3(-5, 0, 0), new Vector3(0, 0, 0), new Vector3(5, 0, 0) };

    private void Start()
    {
        currIndex = 1;
        nextIndex = currIndex;
    }

    void Update()
    {
        //float h = Input.GetAxisRaw("Horizontal");
        //float currX = transform.position.x;

        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            nextIndex++;
        } else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            nextIndex--;
        }

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                initialPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // get the moved direction compared to the initial touch position
                var direction = touch.position - initialPosition;

                // get the signed x direction
                // if(direction.x >= 0) 1 else -1
                var signedDirection = Mathf.Sign(direction.x);

                // are you sure you want to become faster over time?
                nextIndex += (int)signedDirection;
            }
        }

        nextIndex = Mathf.Clamp(nextIndex, 0, 2);

        desiredPosition = directions[nextIndex];

        if (Vector3.Distance(transform.position, desiredPosition) >= 0.1f)
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * lerpSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Camera.main.GetComponent<SceneMan>().GameOver();
        }
    }
}
