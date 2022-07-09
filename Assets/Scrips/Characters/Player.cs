using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : Character
{
    //protected string name;
    //protected float vel;

    //protected GameObject gc;

    protected bool canJump;

    protected int changeop;
    protected int change;

    private void Start()
    {
        //gc = GameObject.FindGameObjectWithTag("GameController");
    }

    private void Update()
    {

    }
    
    protected override void movement() 
	{
        // Movimiento izquierda
        if ((Input.GetKey("left")) || (Input.GetKey(KeyCode.A)))
        {

            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f * Time.deltaTime, 0));
        }

        //Movimiento derecha
        if ((Input.GetKey("right")) || (Input.GetKey(KeyCode.D)))
        {

            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f * Time.deltaTime, 0));
        }
    }

    protected virtual void Jump()
    {
        //Salto
        if (canJump && (Input.GetKeyDown("up")) || (canJump && Input.GetKeyDown(KeyCode.Space)))
        {
            
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
        }
    }

    protected void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            canJump = true;
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.transform.tag == "DMG") || (collision.gameObject.layer == 6))
        {
            if (gc.GetComponent<GameManager>().change != 3)
            {
                dead();
            }
        }

        if ((collision.transform.tag == "DMG1") || (collision.gameObject.layer == 7))
        {
            dead();
        }
    }

    protected override void dead() 
    {        
        GameObject.Destroy(GameObject.FindGameObjectWithTag("Player"));        
    }

    
}
