﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/* 実行中にフレームレートを表示させる */

public class FpsDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textText;

    // 変数
    int frameCount;
    float prevTime;
    float fps;

    // 初期化処理
    void Start()
    {
        // 変数の初期化
        frameCount = 0;
        prevTime = 0.0f;
    }

    // 更新処理
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