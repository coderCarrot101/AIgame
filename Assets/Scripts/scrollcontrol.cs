using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    transform.position = new Vector2(1, 1);// Moving object on a single axis
    Vector3 newPosition = transform.position; // We store the current position
    newPosition.y = 100; // We set a axis, in this case the y axis
    transform.position = newPosition; // We pass it back
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
            Debug.Log("up");
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            Debug.Log("down");
        }
    }
}
