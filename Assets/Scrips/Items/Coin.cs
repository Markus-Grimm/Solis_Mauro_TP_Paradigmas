using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : Item, ICoinsandGemsUP
{
    public GameManager gm;
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");

        if (this.gameObject.tag == "CoinHide")
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    //Cosa de interface
    public void AddCoins()
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

    public void AddGems()
    {        
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            AddCoins();
            GameObject.Destroy(this.gameObject);
        }
    }


    //Cosa de events

    private void Update()
    {
        if (this.tag == "CoinHide")
        {
            if (gc.GetComponent<GameManager>().change == 0)
            {
                ShowOrHideCoins(true);
            }
            else
            {
                ShowOrHideCoins(false);
            }            
        }
        
    }

    void ShowOrHideCoins(bool opt)
    {
        this.GetComponent<SpriteRenderer>().enabled = opt;
        this.GetComponent<CircleCollider2D>().enabled = opt;
    }
}
