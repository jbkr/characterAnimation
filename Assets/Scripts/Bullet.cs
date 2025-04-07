using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;

    void Start()
    {

    }

    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * speed;

        if (transform.position.y > 10)
        {
            gameObject.SetActive(false);
        }
    }


}
