using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShow : MonoBehaviour
{
    public GameObject ButtonText;
    public Text E_text;
    private bool Showbutton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Showbutton)
        {
            ButtonText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Showbutton = false;
                ButtonText.SetActive(false);
            }
        }

        //else if (Input.GetKeyDown(KeyCode.E)) 
        //{
        //    Showbutton = false;
        //    ButtonText.SetActive(false);
        //}
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
            ButtonText.SetActive(false);
        }
    }
}

