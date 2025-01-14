using UnityEngine;
using UnityEngine.SceneManagement;
public class GameClearSC : MonoBehaviour
{
    [SerializeField] Animation imageanima;
    [SerializeField] SceneName.sceneName sceneName;
    CanvasChange cc;
    bool on = false;
    private void Start()
    {
        cc = GameObject.Find("CanvasChange").GetComponent<CanvasChange>();

    }
    public void Clear()
    {
        SceneManager.LoadScene(sceneName.ToString());
        cc.Phase[0] = false;
        cc.Phase[1] = true;
        Debug.Log("くりあ");
        //imageanima.Play();
        //on = true;
    }
    public void Fail()
    {
        SceneManager.LoadScene(sceneName.ToString());
    }

}
