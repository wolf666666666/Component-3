using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction = new Vector2(1, 0);

    private GameObject player = null;
    private Vector3 offset;

    void Start()
    {
        
    }

    void Update()
    {
        Movement();

        PlayerMovement();
    }

    void Movement()
    {
        transform.Translate(speed * direction * Time.deltaTime);
    }

    void PlayerMovement()
    {
        if (player != null)
        {
            player.transform.position = transform.position + offset;
        }
        // This is edited from code which can be found here https://discussions.unity.com/t/how-to-get-a-character-to-move-with-a-moving-platform/1720/3
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            direction = direction * -1;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            offset = player.transform.position - transform.position;
        }
        // This is edited from code which can be found here https://discussions.unity.com/t/how-to-get-a-character-to-move-with-a-moving-platform/1720/3

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        player = null;
    }
}
