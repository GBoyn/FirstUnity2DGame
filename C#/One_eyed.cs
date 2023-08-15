using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_eyed : AllMonsters
{

    //private SpriteRenderer sr;
    //private Color originalColor;
    //public int HP;
    //public int Damage;
    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        //sr = GetComponent<SpriteRenderer>();
        //originalColor = sr.color;
    }

    // Update is called once per frame
    public void Update()
    {

        base.Update();
        //if (HP <= 0) 
        //{
        //    Destroy(gameObject);
        //}
    }
    //public void TakeDamage(int dameage)
    //{
    //    HP -= dameage;
    //    Debug.Log("1");
    //}
    //void FlashColor(float time)
    //{
    //    sr.color = Color.red;
    //    invoke("Resetcolor", time);
    //}
    //void ResetColor()
    //{
    //    sr.color = originalColor;
    //}
}
