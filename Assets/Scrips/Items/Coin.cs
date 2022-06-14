using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            gc.GetComponent<GameManager>().PtsUp(1); 
            GameObject.Destroy(this.gameObject);
        }
    }


}
