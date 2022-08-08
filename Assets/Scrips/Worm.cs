using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{

    [SerializeField] float Speed = 6f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(-Speed * Time.deltaTime, 0, 0);
        //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f * Time.deltaTime, 0));
    }

    private void dead()
    {
        GameObject.Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "EditorOnly" || collision.transform.tag == "Player")
        {
            dead();
        }        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        int a = Random.Range(-1, 1);

        if (collision.transform.tag == "Ground")
        {
            transform.Translate(0, a * Speed * Time.deltaTime, 0);
        }
        else
        {
            transform.Translate(0, Speed * Time.deltaTime, 0);
        }

                
    }

}
