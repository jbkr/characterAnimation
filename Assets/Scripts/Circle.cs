using UnityEngine;

public class Circle : MonoBehaviour
{
    private float bounceSpeed = 5f;
    private float gravity = -9.8f;
    private float groundY = -4f;

    private float verticalSpeed;

    void Update()
    {
        verticalSpeed += gravity * Time.deltaTime;

        transform.position += new Vector3(0, verticalSpeed * Time.deltaTime, 0);

        if (transform.position.y <= groundY)
        {
            transform.position = new Vector3(transform.position.x, groundY, transform.position.z);
            verticalSpeed = bounceSpeed;
        }
    }
}