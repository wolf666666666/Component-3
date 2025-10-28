using UnityEngine;

public class Button : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 direction;
    public GameObject moveableWall1;
    public GameObject player;
    public bool playerInPosition;

    void Start()
    {
        
    }

    void Update()
    {
        PositionCheck();

        if ((playerInPosition == true) && Input.GetKey(KeyCode.E) && moveableWall1.transform.position.y < 8)
        {
            direction = new Vector2(0, 1);
            moveableWall1.transform.Translate(speed * direction * Time.deltaTime);
        }
    }

    void PositionCheck()
    {
        if ((player.transform.position.x > 90) && (player.transform.position.x < 93))
        {
            playerInPosition = true;
        }
        else
        {
            playerInPosition = false;
        }
    }
}
