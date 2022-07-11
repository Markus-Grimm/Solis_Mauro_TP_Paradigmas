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

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");
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
