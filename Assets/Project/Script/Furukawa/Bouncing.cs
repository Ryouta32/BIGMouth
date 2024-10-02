using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    [SerializeField] private Transform trackingspace;
    [SerializeField] private GameObject rightControllerPivot;
    [SerializeField] private OVRInput.RawButton actionBtn;
    [SerializeField] private GameObject ball;

    private GameObject currentBall;
    private bool ballGrabbed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (!ballGrabbed && OVRInput.GetDown(actionBtn))
        {
            currentBall = Instantiate(ball, rightControllerPivot.transform.position, Quaternion.identity);
            currentBall.transform.parent = rightControllerPivot.transform;
            ballGrabbed = true;
        }

        if (ballGrabbed && OVRInput.GetUp(actionBtn))
        {
            currentBall.transform.parent = null;
            ballGrabbed = false;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            ballGrabbed = false;
        }
    }
}
