using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player0 : Player
{
        
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");
        
    }

    void Update()
    {
        movement();
        Jump();


        if (this.transform.position.y <= -12)
        {
            dead();
        }


    }


}
