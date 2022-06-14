using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemB : Item
{

    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            gc.GetComponent<GameManager>().cantGB = gc.GetComponent<GameManager>().cantGB + 1;
            gc.GetComponent<GameManager>().gemB_txt.text = "x" + gc.GetComponent<GameManager>().cantGB;
            GameObject.Destroy(this.gameObject);
        }
    }


}
