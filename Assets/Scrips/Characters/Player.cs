using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    //protected string name;
    //protected float vel;


    protected bool canJump;

    protected int changeop;
    protected int change;

    //Events
    private delegate void Items();
    Items evento;

    private int gem = 1;

    private Animator animator;

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");
        animator = this.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        movement();
        Jump();
        
        if (this.transform.position.y <= -20)
        {
            dead();
        }
    }
    
    protected override void movement() 
	{
        // Movimiento izquierda
        if ((Input.GetKey("left")) || (Input.GetKey(KeyCode.A)))
        {
            animator.SetBool("mov", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f * Time.deltaTime, 0));            
        }
        

        //Movimiento derecha
        if ((Input.GetKey("right")) || (Input.GetKey(KeyCode.D)))
        {

            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f * Time.deltaTime, 0));
            animator.SetBool("mov", true);
        }

        if ((Input.GetKeyUp("left")) || (Input.GetKeyUp(KeyCode.A)) || (Input.GetKeyUp("right")) || (Input.GetKeyUp(KeyCode.D)))
        {
            animator.SetBool("mov", false);
        }
    }

    protected virtual void Jump()
    {
        //Salto
        if (canJump && (Input.GetKeyDown("up")) || (canJump && Input.GetKeyDown(KeyCode.Space)))
        {
            //animator.SetBool("mov", false);
            animator.SetBool("jump", true); 
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));            
        }
    }

   /* protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            //animator.SetBool("mov", false);
            animator.SetBool("jump", true);
        }
    }*/

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            animator.SetBool("jump", false); 
            canJump = true;            
        }

        if ((collision.gameObject.layer == 6))
        {
            if ((collision.transform.tag == "DMG") && (gc.GetComponent<GameManager>().change != 3))
            {
                dead();
            }

            if (collision.transform.tag == "Enemy")
            {
                if (gc.GetComponent<GameManager>().change != 3)
                {
                    dead();
                }
                else
                {
                    GameObject.Destroy(collision.gameObject);
                }                
            }            
        }


        if (collision.transform.tag == "Finish")
        {
            this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            gc.GetComponent<GameManager>().win = true;
        }

        if ((collision.transform.tag == "DMG1") || (collision.gameObject.layer == 7))
        {
            dead();
        }

        if (collision.gameObject.layer == 3)
        {
            for (int i = 0; i < gc.GetComponent<GameManager>().Gemas.Length; i++)
        {
            if (collision.transform.tag == gc.GetComponent<GameManager>().Gemas[i].transform.tag)
            {
                gem = i;

                if (evento != null)
                {
                    evento -= AddCoins;
                    evento -= AddGems;
                }
                
                evento += AddCoins;
                evento += AddGems;
                evento();

                GameObject.Destroy(collision.gameObject);
            }
        }
        }

        

    }

    private void AddCoins()
    {
        if (gc.GetComponent<GameManager>().change == 2)
        {
            gc.GetComponent<GameManager>().PtsUp(3);
        }
        else
        {
            gc.GetComponent<GameManager>().PtsUp(1);
        }
    }

    private void AddGems()
    {        
        gc.GetComponent<GameManager>().CantGemas[gem] = gc.GetComponent<GameManager>().CantGemas[gem] + 1;
        gc.GetComponent<GameManager>().GemsText[gem].text = "x" + gc.GetComponent<GameManager>().CantGemas[gem];
    }

    protected override void dead() 
    {        
        GameObject.Destroy(GameObject.FindGameObjectWithTag("Player"));        
    }

    
}
