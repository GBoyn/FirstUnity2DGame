using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHPUI : MonoBehaviour
{
    public Text HPNumber;
    public int HPMAX;
    public static int TrueMaxHP;
    public static int HPCurrent;

    private Image PlayerHPUIS;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHPUIS = GetComponent<Image>();
        HPCurrent = HPMAX;
        TrueMaxHP = HPMAX;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHPUIS.fillAmount = (float)HPCurrent /(float) HPMAX; ;
        HPNumber.text = HPCurrent.ToString()+"/"+HPMAX.ToString();
    }
}
