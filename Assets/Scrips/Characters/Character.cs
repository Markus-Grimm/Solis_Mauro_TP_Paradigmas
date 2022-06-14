using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
	protected GameObject gc;
	//protected string name;
	protected float vel;
	
	protected virtual void movement() { }

	protected virtual void dead() { }

    private void Start()
    {
		//gc = GameObject.FindGameObjectWithTag("GameController");
	}

}
