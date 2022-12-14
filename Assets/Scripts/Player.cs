using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpAmount = 35;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    public bool jump = false;

    [SerializeField]
    KeyCode left;
    [SerializeField]
    KeyCode right;
    [SerializeField]
    KeyCode space;
    [SerializeField]
    KeyCode dash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.playerHealth > 0)
        {
            movement();
        }
       
    }
    void movement()
    {
        if (Input.GetKey(right))
        {
            transform.position += new Vector3(8, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(left))
        {
            transform.position += new Vector3(-8, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jump == false)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            jump = true;
        }
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
  
    }
      void OnCollisionEnter2D(Collision2D collision)
      {
        if (collision.gameObject.tag == "floor")
        {
            jump = false;
        }
    }
 }

