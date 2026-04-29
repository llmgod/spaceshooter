using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public GameObject Explosion;

    public Sprite[] Sprites;
    public float Speed;

    [Range(0, 1)]
    public float MoveDownFactor = 0.5f;

    public UnityEvent OnDead;

    protected float xSpeed, ySpeed;

    protected SpriteRenderer spriteRenderer;

    protected Vector3 screenSize;

    public int health = 3;

    protected void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int index = Random.Range(0, Sprites.Length);
        spriteRenderer.sprite = Sprites[index];

        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        ySpeed = -1;
    }

    void Update()
    {
        Vector3 velocity = new Vector3(xSpeed, ySpeed);
        transform.position += velocity.normalized * Speed * Time.deltaTime;

        if (transform.position.x < -screenSize.x)
        {
            xSpeed = 1;
        }
        else if (transform.position.x > screenSize.x)
        {
            xSpeed = -1;
        }

        if (transform.position.y > screenSize.y)
        {
            ySpeed = -1;
        }
        else if (transform.position.y < screenSize.y * MoveDownFactor)
        {
            if (xSpeed == 0)
            {
                int value = Random.Range(0, 2);
                if (value == 0)
                {
                    xSpeed = 1;
                }
                else
                {
                    xSpeed = -1;
                }
            }
            ySpeed = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLaser"))
        {
            GameObject clone = Instantiate(Explosion);
            clone.transform.position = transform.position;

            Destroy(collision.gameObject);

            TakeDamage(1);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            OnDead?.Invoke();
            Destroy(gameObject);
        }
    }
}
