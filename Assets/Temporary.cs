using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    Transform enemy;
    float distance;
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
    [SerializeField]
    float jumpTimer = 5f;
    [SerializeField]
    float walkSpeedCloseToPlayer =7;
    void Start()
    {

    }
    void Update()
    {
        distance = (player.transform.position.x - transform.position.x);
        if (GameManager.playerHealth > 0)
        {
            jumpTimer -= 1f * Time.deltaTime;
            if (Vector2.Distance(player.position, enemy.position) < 5)
            {
                transform.position += new Vector3(walkSpeedCloseToPlayer * walkDirection * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.position += new Vector3(walkSpeed * walkDirection * Time.deltaTime, 0, 0);
            }
            if (jumpTimer <= 0 && inAir == false)
            {
                rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                inAir = true;
                jumpTimer = Random.Range(2, 5);
            }
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
