using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Temporary : MonoBehaviour
{
    Vector3 respawn = new Vector3(-10f, 2f, 0);
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float jumpHeight = 1f;
    [SerializeField]
    bool inAir;
    //if variable walkDirection is positive, the enemy will walk to the right. if its negative, the enemy will walk to the left
    int walkDirection = 1;
    [SerializeField]
    int walkSpeed = 5;
    float jumpTimer = 5f;
    void Start()
    {

    }
    void Update()
    {
        jumpTimer -= 1f * Time.deltaTime;
        transform.position += new Vector3(walkSpeed * walkDirection * Time.deltaTime, 0, 0);
        if (jumpTimer<= 0&& inAir == false)
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            inAir = true;
            jumpTimer = Random.Range(2, 5);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            walkDirection *= -1;
        }
        if(collision.gameObject.tag == "floor")
        {
            inAir = false;
        }
        if (collision.gameObject.tag == "player")
        {
            collision.gameObject.transform.position = respawn;
            GameManager.playerHealth--;
        }
    }
}
