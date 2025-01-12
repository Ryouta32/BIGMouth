using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameClearSC : MonoBehaviour
{
    [SerializeField] Animation imageanima;
    [SerializeField] SceneName.sceneName sceneName;
    bool on = false;
    public void Clear()
    {
        SceneManager.LoadScene(sceneName.ToString());
        //imageanima.Play();
        //on = true;
    }

}
