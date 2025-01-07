using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameClearSC : MonoBehaviour
{
    [SerializeField] Animation imageanima;
    bool on = false;
    public void Clear()
    {
        imageanima.Play();
        on = true;
    }

}
