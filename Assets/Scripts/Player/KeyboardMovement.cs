using UnityEngine;
using System.Collections;

public class KeyboardMovement : MonoBehaviour
{
    float speed = 10.0f;

    void Update()
    {
        float movement = Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveXY(-movement, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveXY(movement, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveXY(0, movement);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveXY(0, -movement);
        }
    }

    void moveXY(float x, float y)
    {
        transform.Translate(x, 0.0f, y);
    }
}
