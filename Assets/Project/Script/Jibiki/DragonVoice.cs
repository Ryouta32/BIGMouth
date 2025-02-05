using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonVoice : MonoBehaviour
{
    public static bool MushDown = false;
    public static bool TentacleDown = false;

    private void OnEnable()
    {
        StartCoroutine("TyuubetaVoice");
    }

    IEnumerator TyuubetaVoice()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);

            if (MushDown)
            {
                MushVoice();
            }
            else if (TentacleDown)
            {
                TentacleVoice();
            }
            else if (MushDown && TentacleDown)
            {
                BothVoice();
            }
            else
            {
                gameObject.SetActive(false);
                break;
            }
        }
    }

    void MushVoice()
    {
        AudioManager.manager.PlayPoint(AudioManager.manager.data.kinokotaosu, this.gameObject);
    }

    void TentacleVoice()
    {
        AudioManager.manager.PlayPoint(AudioManager.manager.data.syokusyutaosu, this.gameObject);
    }

    void BothVoice()
    {
        AudioManager.manager.PlayPoint(AudioManager.manager.data.kinokotosyokusyu, this.gameObject);
    }
}
