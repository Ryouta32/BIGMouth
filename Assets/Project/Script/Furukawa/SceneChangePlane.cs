//using Meta.XR.Editor.Tags;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangePlane : MonoBehaviour
{
    [SerializeField, Tag] private string _tagName;
    [SerializeField] SceneName.sceneName name;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag(_tagName.ToString()))
            SceneManager.LoadScene(name.ToString());
    }
}
