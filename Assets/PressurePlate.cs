using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class PressurePlate : MonoBehaviour
{
    public GameObject moveableWall;
    private Vector2 direction;
    public float speed = 5f;
    public bool playerOn = false;

    void Start()
    {
        
    }

    void Update()
    {
        if ((playerOn == false) && (moveableWall.transform.position.y < 2))
        {
            direction = new Vector2(0, 1);
            moveableWall.transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOn = true;
            direction = new Vector2(0, -1);
            moveableWall.transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        playerOn = false;
    }
}
