using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    private float speed = 2f;
    private float zigzagSpeed = 2f;
    private float zigzagAmount = 2f;
    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        // moves downward and zigzags at the same time
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        float newX = startX + Mathf.Sin(Time.time * zigzagSpeed) * zigzagAmount;
        transform.position = new Vector3(newX, transform.position.y, 0);

        // delete when it goes off the bottom of the screen
        if (transform.position.y < -7f)
            Destroy(gameObject);
    }
}