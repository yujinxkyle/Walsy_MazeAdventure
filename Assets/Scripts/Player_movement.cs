using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    private int keysCollected = 0;

    public GameObject door;

    public Sprite doorOpenSprite;   
    public Sprite doorClosedSprite;


    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetDoorSprite(doorClosedSprite);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) 
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            //face left direction when A is pressed
            SetObjectFacingDirection(true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            //face right direction when D is pressed
            SetObjectFacingDirection(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            keysCollected++;

            GameObject wall = GameObject.Find("temporary_wall");
            if (keysCollected == 1 && wall != null)
            {
                Destroy(wall);
            }
            
            GameObject wall_1 = GameObject.Find("temporary_wall_2");
            if (keysCollected >= 2 && door != null)
            {
                Destroy(wall_1);
                
                UnlockDoor();
            }

        }
        //game restarts when you hit an obstacle
        else if (collision.gameObject.tag == "Obstacles")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //prevent player to pass through walls
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
             
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            
        }
    }

    private void SetObjectFacingDirection(bool facingLeft)
    {
        // Flip the character based on facing left
        spriteRenderer.flipX = facingLeft;
    }

//for door
    private void UnlockDoor()
    {
        if (door != null)
        {
            SetDoorSprite(doorOpenSprite);
            DisableDoorCollider();
        }
    }

    private void SetDoorSprite(Sprite sprite)
    {
        // Set the door sprite
        if (door != null)
        {
            SpriteRenderer doorRenderer = door.GetComponent<SpriteRenderer>();
            if (doorRenderer != null)
            {
                doorRenderer.sprite = sprite;
            }
        }
    }

    private void DisableDoorCollider()
    {
        // Disable the door's collider
        Collider2D doorCollider = door.GetComponent<Collider2D>();
        if (doorCollider != null)
        {
            doorCollider.enabled = false;
        }
    }

}
