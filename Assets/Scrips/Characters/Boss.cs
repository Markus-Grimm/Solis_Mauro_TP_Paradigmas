using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    [SerializeField] GameObject launchposition;
    [SerializeField] GameObject projectile;
    [SerializeField] Animator anim;
    [SerializeField] float time;
    [SerializeField] float timeatk = 2.3f;



    void Start()
    {
        time = Random.Range(2f, 6f);
        StartCoroutine(TimeWait(time));
    }


    public IEnumerator TimeWait(float valcrono)
    {

        yield return new WaitForSeconds(valcrono);        
        StartCoroutine(AnimChange(timeatk));

    }

    public IEnumerator AnimChange(float valcrono)
    {
        anim.SetBool("ATK", true);

        yield return new WaitForSeconds(valcrono);

        anim.SetBool("ATK", false);

        time = Random.Range(2f, 6f);
        StartCoroutine(TimeWait(time));
    }

    public void Shooting()
    {
        Instantiate(projectile, launchposition.transform.position - new Vector3(0.6f, 0, 0), launchposition.transform.rotation);
        
    }

}
