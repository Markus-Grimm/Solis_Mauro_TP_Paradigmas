using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemR : Item
{

    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            gc.GetComponent<GameManager>().cantGR = gc.GetComponent<GameManager>().cantGR + 1;
            gc.GetComponent<GameManager>().gemR_txt.text = "x" + gc.GetComponent<GameManager>().cantGR;
            GameObject.Destroy(this.gameObject);
        }
    }

}
