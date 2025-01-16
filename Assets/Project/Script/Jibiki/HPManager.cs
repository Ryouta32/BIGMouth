using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    Image UI_HP;
    public static float hp;
    public static float hpPiece;

    // Start is called before the first frame update
    void Start()
    {
        UI_HP = GameObject.Find("HP").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        UI_HP.fillAmount = hpPiece / hp;
    }
}
