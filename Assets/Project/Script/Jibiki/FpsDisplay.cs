using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/*���s���Ƀt���[�����[�g��\��������*/

public class FpsDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textText;

    // �ϐ�
    int frameCount;
    float prevTime;
    float fps;

    // ����������
    void Start()
    {
        // �ϐ��̏�����
        frameCount = 0;
        prevTime = 0.0f;
    }

    // �X�V����
    void Update()
    {
        frameCount++;
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= 0.5f)
        {
            fps = frameCount / time;
            //Debug.Log(fps);

            textText.text = fps.ToString("F2");

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }
    }
}