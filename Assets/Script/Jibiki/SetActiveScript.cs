using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveScript : MonoBehaviour
{
    //[SerializeField] GameObject maincamera;
    //[SerializeField] GameObject subcamera;
    [SerializeField] GameObject camera;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = camera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            //maincamera.SetActive(false);
            //subcamera.SetActive(true);
            cam.clearFlags = CameraClearFlags.Skybox;
        }
        if (OVRInput.Get(OVRInput.Button.One))
        {
            //maincamera.SetActive(true);
            //subcamera.SetActive(false);
            cam.clearFlags = CameraClearFlags.SolidColor;
        }
    }
}
