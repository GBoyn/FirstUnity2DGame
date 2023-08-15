using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleNumber : MonoBehaviour
{
    public int startAppleNumber;
    public Text AppleNumberS;

    public static int CurrentAppleNumber;
    // Start is called before the first frame update
    void Start()
    {
        CurrentAppleNumber = startAppleNumber;
    }

    // Update is called once per frame
    void Update()
    {
        AppleNumberS.text = CurrentAppleNumber.ToString();
    }
}
