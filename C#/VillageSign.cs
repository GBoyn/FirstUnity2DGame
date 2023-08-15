using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillageSign : MonoBehaviour
{
    public GameObject village_sign;
    public Text Village_text;
    public string VillageShow_text;
    private bool Showbutton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Showbutton) 
        {
            Village_text.text = VillageShow_text ;
            village_sign.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            Showbutton = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            Showbutton = false;
            village_sign.SetActive(false);
        }
    }
}
