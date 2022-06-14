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

    public GameObject GY, GR, GB, GG;
    public int cantGY, cantGR, cantGB, cantGG;

    public int changeop, change;

    //Gemas
    public GameObject gemR, gemB, gemG, gemY, coin;

    public Text gemR_txt, gemB_txt, gemG_txt, gemY_txt, coins_txt;

    public int coins;

    //Cambio
    public SpriteRenderer SpriteRenderer;
    public Sprite red, blue, green, yellow;

    public Animator anim;

    void Start()
    {
        coins = 0;
        
        lose = false;
        reset = false;

        GY = GameObject.FindGameObjectWithTag("IFGemY");
        GY.SetActive(false);
        cantGY = 0; 
        GR = GameObject.FindGameObjectWithTag("IFGemR");
        cantGR = 0; 
        GG = GameObject.FindGameObjectWithTag("IFGemG");
        GG.SetActive(false); 
        cantGG = 0; 
        GB = GameObject.FindGameObjectWithTag("IFGemB");
        GB.SetActive(false); 
        cantGB = 0;

        changeop = 0;
        change = 2;

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
            Change(changeop);            
        }
    }

    public void PtsUp(int x)
    {
        coins = coins + x;
        coins_txt.text = "x" + coins;
    }

    public void ChangeOption(int opt)
    {
        switch (opt)
        {
            case 0:
                gemR.SetActive(true);
                gemB.SetActive(false);
                gemG.SetActive(false);
                gemY.SetActive(false);
                break;

            case 1:
                gemR.SetActive(false);
                gemB.SetActive(true);
                gemG.SetActive(false);
                gemY.SetActive(false);
                break;

            case 2:
                gemR.SetActive(false);
                gemB.SetActive(false);
                gemG.SetActive(true);
                gemY.SetActive(false);
                break;

            case 3:
                gemR.SetActive(false);
                gemB.SetActive(false);
                gemG.SetActive(false);
                gemY.SetActive(true);
                break;

            default:
                break;
        }
    }

    public void Change(int opt)
    {
        change = changeop;

        /*   Cambiar esto por un for
        switch (opt)
        {
            case 0:
                if (cantGR > 0)
                {
                    SpriteRenderer.sprite = red;
                    cantGR = cantGR - 1;
                    gemR_txt.text = "x" + cantGR;
                    player.GetComponent<Player0>().enabled = true;                    
                    player.GetComponent<Player1>().enabled = false;
                    player.GetComponent<Player2>().enabled = false;
                    player.GetComponent<Player3>().enabled = false;
                    anim.SetBool("New Bool", false);
                }
                break;

            case 1:
                if (cantGB > 0)
                {
                    SpriteRenderer.sprite = blue;
                    cantGB = cantGB - 1;
                    gemB_txt.text = "x" + cantGB;
                    player.GetComponent<Player0>().enabled = false;
                    player.GetComponent<Player1>().enabled = true;
                    player.GetComponent<Player2>().enabled = false;
                    player.GetComponent<Player3>().enabled = false;
                    anim.SetBool("New Bool", true);
                }
                break;

            case 2:
                if (cantGG > 0)
                {
                    SpriteRenderer.sprite = green;
                    cantGG = cantGG - 1;
                    gemG_txt.text = "x" + cantGG;
                    player.GetComponent<Player0>().enabled = false;
                    player.GetComponent<Player1>().enabled = false;
                    player.GetComponent<Player2>().enabled = true;
                    player.GetComponent<Player3>().enabled = false;
                    anim.SetBool("New Bool", true);
                }
                break;

            case 3:
                if (cantGY > 0)
                {
                    SpriteRenderer.sprite = yellow;
                    cantGY = cantGY - 1;
                    gemY_txt.text = "x" + cantGY;
                    player.GetComponent<Player0>().enabled = false;
                    player.GetComponent<Player1>().enabled = false;
                    player.GetComponent<Player2>().enabled = false;
                    player.GetComponent<Player3>().enabled = true;
                    anim.SetBool("New Bool", true);
                }
                break;

            default:
                break;
        
        }*/
    }
        
}
