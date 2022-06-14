using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemG : Item
{

    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            gc.GetComponent<GameManager>().cantGG = gc.GetComponent<GameManager>().cantGG + 1;
            gc.GetComponent<GameManager>().gemG_txt.text = "x" + gc.GetComponent<GameManager>().cantGG;
            GameObject.Destroy(this.gameObject);
        }
    }


}
