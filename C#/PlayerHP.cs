using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int playerHP;
    private Renderer myRender;
    public int Blinks;
    public float BlinkTime;
    private Animator anim;
    private bool m_noBlood = false;
    //private bool m_rolling = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRender = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q") && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && AppleNumber.CurrentAppleNumber > 0)
        {
            ADDHP();
        }
    }

    public void DamegePlayer(int damege)
    {

        //if (!m_rolling)
        //{
        //    playerHP -= damege;
        //    anim.SetTrigger("Hurt");
        //    if (playerHP <= 0)
        //    {
        //        anim.SetBool("noBlood", m_noBlood);
        //        anim.SetTrigger("Death");
        //        //Destroy(gameObject);
        //        Invoke("KillPlayer", 3.0f);
        //    }
        //    BlinkPlayer(Blinks, BlinkTime);
        //}
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Roll") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Block") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Idle Block") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Death")) 
        {
            playerHP -= damege;
            anim.SetTrigger("Hurt");
            PlayerHPUI.HPCurrent = playerHP;
            if (playerHP <= 0)
            {
                playerHP = 0;
                anim.SetBool("noBlood", m_noBlood);
                anim.SetTrigger("Death");
                PlayerHPUI.HPCurrent = playerHP;
                //Destroy(gameObject);
                Invoke("KillPlayer", 3.0f);
            }
            BlinkPlayer(Blinks, BlinkTime);
        }

        //else
        //{
        //    playerHP -= damege;
        //    anim.SetTrigger("Hurt");
        //    if (playerHP <= 0)
        //    {
        //        anim.SetBool("noBlood", m_noBlood);
        //        anim.SetTrigger("Death");
        //        //Destroy(gameObject);
        //        Invoke("KillPlayer", 3.0f);
        //    }
        //    BlinkPlayer(Blinks, BlinkTime);
        //}
        //playerHP -= damege;
        //anim.SetTrigger("Hurt");
        //if (playerHP <= 0)
        //{
        //    anim.SetBool("noBlood", m_noBlood);
        //    anim.SetTrigger("Death");
        //    //Destroy(gameObject);
        //    Invoke("KillPlayer", 3.0f);
        //}
        //BlinkPlayer(Blinks, BlinkTime);
    }

    void KillPlayer()
    {
        Destroy(gameObject);
    }

    void BlinkPlayer(int num, float Blinktime)
    {
        StartCoroutine(DoBlink(num, Blinktime));
    }

    void ADDHP()
    {
        //if (Input.GetKeyDown("q") && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        //{
            Debug.Log("ADD");
        if (playerHP < PlayerHPUI.TrueMaxHP)
        {
            playerHP += 5;
        }

            //playerHP += 5;
            PlayerHPUI.HPCurrent = playerHP;
        //}
    }

    IEnumerator DoBlink(int num, float BlinkTime)
    {
        for (int i = 0; i < num * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(BlinkTime);
        }
        myRender.enabled = true;
    }

}
