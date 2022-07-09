using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //Movimiento y camara
    public GameObject player;
    public new Camera camera;

    public bool lose, reset;
    public Text GameOver;

    public int life, state;

    public GameObject[] Gemas;
    public int[] CantGemas;

    public int changeop, change;

    //Gemas
    public GameObject coin;
    public GameObject[] GemsUI;
    public Text coins_txt;
    public Text[] GemsText; 

    public int coins;

    //Cambio
    public SpriteRenderer SpriteRenderer;
    public Sprite[] Sprites;

    public Animator anim;

    void Start()
    {
        coins = 0;
        
        lose = false;
        reset = false;

        for (int i = 0; i < CantGemas.Length; i++)
        {
            CantGemas[i] = 0;
        }

        for (int i = 0; i < GemsUI.Length; i++)
        {
            if (i != 1)
            {
                GemsUI[i].SetActive(false);
            }
        }

        changeop = 1;
        change = 1;

        SpriteRenderer = player.GetComponent<SpriteRenderer>();

        player.GetComponent<Player0>().enabled = false;
        player.GetComponent<Player1>().enabled = false;
        player.GetComponent<Player2>().enabled = true;
        player.GetComponent<Player3>().enabled = false;
    }

    void Update()
    {
        if (player != null)
        {
            camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, camera.transform.position.z);
        }
        else
        {
            GameOver.text = "Game Over\nPress T to restart";
            player = GameObject.FindGameObjectWithTag("PlayerSust");
            reset = true;
        }

        if (reset && (Input.GetKeyDown(KeyCode.T)))
        {
            reset = false;
            SceneManager.LoadScene("Gameplay");
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (changeop < 3)
            {
                changeop = changeop + 1;
                ChangeOption(changeop);
            }
            else
            {
                changeop = 0;
                ChangeOption(changeop);
            }
        }

        if ((Input.GetKeyDown(KeyCode.E)) && change != changeop)
        {
            if (CantGemas[changeop] > 0)
            {
                Change(changeop);
            }                        
        }
    }

    public void PtsUp(int x)
    {
        if (coins + x < 20)
        {
            coins = coins + x;
            coins_txt.text = "x" + coins;
        }
        else
        {
            CantGemas[3] = CantGemas[3] + 1;
            GemsText[3].text = "x" + CantGemas[3];
            coins = coins + x - 20;
            coins_txt.text = "x" + coins;
        }
        
        
    }

    public void ChangeOption(int opt)
    {        
        for (int i = 0; i < Gemas.Length; i++)
        {
            if (opt == i)
            {
                Gemas[i].SetActive(true);
            }
            else
            {
                Gemas[i].SetActive(false);
            }
        }        
    }


    public void Change(int opt)
    {
        change = changeop;

        for (int i = 0; i < 4; i++)
        {
            if (i == opt)
            {
                SpriteRenderer.sprite = Sprites[i];
                CantGemas[i] = CantGemas[i] - 1;
                GemsText[i].text = "x" + CantGemas[i];
            }
        }

        player.GetComponent<Player0>().enabled = false;
        player.GetComponent<Player1>().enabled = false;
        player.GetComponent<Player2>().enabled = false;
        player.GetComponent<Player3>().enabled = false;

        switch (opt)
        {
            case 0:
                {    
                    player.GetComponent<Player0>().enabled = true;
                    anim.SetBool("New Bool", false);
                    player.GetComponent<Rigidbody2D>().gravityScale = 6;
                    player.GetComponent<Rigidbody2D>().mass = 0.24f;
                }
                break;

            case 1:
                {
                    player.GetComponent<Player1>().enabled = true;
                    anim.SetBool("New Bool", true);
                    player.GetComponent<Rigidbody2D>().gravityScale = 6;
                    player.GetComponent<Rigidbody2D>().mass = 0.24f;
                }
                break;

            case 2:
                {
                    player.GetComponent<Player2>().enabled = true;
                    anim.SetBool("New Bool", true);
                    player.GetComponent<Rigidbody2D>().gravityScale = 8;
                    player.GetComponent<Rigidbody2D>().mass = 0.24f;
                }
                break;

            case 3:
                {
                    player.GetComponent<Player3>().enabled = true;
                    anim.SetBool("New Bool", true);
                    player.GetComponent<Rigidbody2D>().gravityScale = 6;
                    player.GetComponent<Rigidbody2D>().mass = 0.4f;
                }
                break;

            default:
                break;
        
        }
    }

}
