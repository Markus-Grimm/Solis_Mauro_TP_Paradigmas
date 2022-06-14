using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemY : Item
{

    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            gc.GetComponent<GameManager>().cantGY = gc.GetComponent<GameManager>().cantGY + 1;
            gc.GetComponent<GameManager>().gemY_txt.text = "x" + gc.GetComponent<GameManager>().cantGY; 
            GameObject.Destroy(this.gameObject);
        }
    }

}
