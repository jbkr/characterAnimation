using UnityEngine;

public class Circle1 : MonoBehaviour
{
    private float velocity;

    public float acceleration = -9.8f;

    public float movingSpeed = 3.0f;

    private bool isRight = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");

        collision.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (transform.position.y <= -3.13f)
        {
            velocity = -velocity;
        }

        velocity += acceleration * Time.deltaTime;
        transform.position += new Vector3(0, velocity * Time.deltaTime, 0);

        if (transform.position.x < -9.0f)
        {
            isRight = true;
        }
        else if (transform.position.x > 9.0f)
        {
            isRight = false;
        }

        if (isRight)
        {
            transform.position += Vector3.right * Time.deltaTime * movingSpeed;
        }
        else
        {
            transform.position += Vector3.left * Time.deltaTime * movingSpeed;
        }
    }
}
