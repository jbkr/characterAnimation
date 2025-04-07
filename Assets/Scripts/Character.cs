using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private Sprite[] idleSprites;

    [SerializeField]
    private Sprite[] walkSprites;

    private SpriteRenderer spriteRenderer;

    private enum STATE
    {
        IDLE,
        WALK,
    }

    private STATE state;

    public float runSpeed = 5.0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void MoveInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * runSpeed;
            spriteRenderer.flipX = true;
            state = STATE.WALK;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * runSpeed;
            spriteRenderer.flipX = false;
            state = STATE.WALK;
        }
        else
        {
            state = STATE.IDLE;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject resourceBullet = Resources.Load<GameObject>("Prefabs/Bullet");
            GameObject sceneBullet = Instantiate(resourceBullet);

            sceneBullet.transform.position = new Vector3(transform.position.x, -2.5f, 0);
        }
    }

    private float accTime;
    private int currentIndex;

    private void IdleAction()
    {
        MoveInput();
        AnimateCharacter(idleSprites);
    }

    private void WalkAction()
    {
        MoveInput();
        AnimateCharacter(walkSprites);
    }

    private void AnimateCharacter(Sprite[] sprites)
    {
        if (currentIndex >= sprites.Length)
        {
            currentIndex = 0;
        }

        spriteRenderer.sprite = sprites[currentIndex];

        accTime += Time.deltaTime;

        if (accTime > 0.1f)
        {
            currentIndex++;
            accTime = 0f;
        }
    }

    void Update()
    {
        switch (state)
        {
            case STATE.IDLE:
                IdleAction();
                break;
            case STATE.WALK:
                WalkAction();
                break;
            default:
                break;
        }
    }
}
