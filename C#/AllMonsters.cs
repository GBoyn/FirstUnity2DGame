using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllMonsters : MonoBehaviour
{
    public int HP;
    public int Damage;
    private SpriteRenderer sr;
    private Color originalColor;
    public float flashtime;
    public GameObject blood;
    private PlayerHP PlayerHP;
    // Start is called before the first frame update
    public void Start()
    {
        PlayerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    // Update is called once per frame
    public void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int dameage)
    {
        HP -= dameage;
        Debug.Log("1");
        FlashColor(flashtime);
        Instantiate(blood, transform.position, Quaternion.identity);
    }
    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }
    void ResetColor()
    {
        sr.color = originalColor;
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
    //    {
    //        if (PlayerHP != null)
    //        {
    //            PlayerHP.DamegePlayer(Damage);
    //        }
    //    }
    //}
}
