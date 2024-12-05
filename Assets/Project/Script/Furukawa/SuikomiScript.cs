using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuikomiScript : MonoBehaviour
{
    private BouSakiScript sakiScript;
    [Header("吸い込んだ時のポイント")]
    [SerializeField] float point;
    private void OnDestroy()
    {
        sakiScript.AddShowerPoint(point);
    }
    public void SetBousaki(BouSakiScript bou) => sakiScript = bou;
}
