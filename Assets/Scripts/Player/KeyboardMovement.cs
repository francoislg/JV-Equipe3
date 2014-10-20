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
            MoveXY(-movement, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveXY(movement, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveXY(0, movement);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveXY(0, -movement);
        }
    }

    void MoveXY(float x, float y)
    {
        transform.Translate(x, 0.0f, y);
    }
}
