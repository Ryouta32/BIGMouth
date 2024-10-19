#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System.Media;
using UnityEngine;

public class BuildSoundNotifier : IPostprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }

    public void OnPostprocessBuild(BuildReport report)
    {
        if (report.summary.platform == BuildTarget.Android)
        {
            // Meta Quest 3のビルドが完了した際に音を鳴らす
            SystemSounds.Beep.Play(); // Windowsのビープ音
            Debug.Log("Meta Quest 3にビルド＆ランが完了しました！");
        }
    }
}
#endif