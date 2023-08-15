using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterattack : MonoBehaviour
{
    private PlayerHP PlayerHP;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            if (PlayerHP != null)
            {
                PlayerHP.DamegePlayer(damage);
            }
        }
    }
}
