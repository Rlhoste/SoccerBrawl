using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public float jumpForce = 1f;
    public float moveSpeed = 5f;
    public int maxNbJump = 2;
    public int nbJump = 0;
    public bool facingRight = true;



    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        jump();
        move();

        if(facingRight == false && Input.GetAxis("Horizontal") > 0)
        {
            flip();
        } else if(facingRight == true && Input.GetAxis("Horizontal") < 0)
        {
            flip();
        }
    }

    void flip()
    {
        print("flip");
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        nbJump = 0;
        //print("Collisding with");
    }

    void jump()
    {

        if (Input.GetButtonDown("Jump") && nbJump < maxNbJump)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            nbJump++;
        }

    }
}
