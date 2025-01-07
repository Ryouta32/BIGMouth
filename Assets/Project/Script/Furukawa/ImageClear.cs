using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ImageClear : MonoBehaviour
{
public void Scene()
    {
        SceneManager.LoadScene(SceneName.sceneName.ClearScene.ToString());
    }
}
