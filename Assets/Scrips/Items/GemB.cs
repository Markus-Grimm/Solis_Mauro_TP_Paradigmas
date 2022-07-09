using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemB : Item, ICoinsandGemsUP
{
    private int x = 3;

    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");
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
        gc.GetComponent<GameManager>().CantGemas[x] = gc.GetComponent<GameManager>().CantGemas[x] + 1;
        gc.GetComponent<GameManager>().GemsText[x].text = "x" + gc.GetComponent<GameManager>().CantGemas[x];
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            AddGems();
            AddCoins();
            GameObject.Destroy(this.gameObject);
        }
    }


}
