using UnityEngine;
public class SuikomiScript : MonoBehaviour
{
    public BouSakiScript sakiScript;
    [Header("吸い込んだ時のポイント")]
    [SerializeField] float point;
    GameClearSC clearSC;
    private void OnDestroy()
    {
        //Debug.Log(gameObject.name);
        sakiScript.AddShowerPoint(point);
        AudioManager.manager.PlayPoint(AudioManager.manager.data.charge, sakiScript.gameObject);
        //if (clearSC != null)
        //    clearSC.Clear();
    }
    public void SetClear(GameClearSC sc) => clearSC = sc;
    public void SetBousaki(BouSakiScript bou) => sakiScript = bou;
}
