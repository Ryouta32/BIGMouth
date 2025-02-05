using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonVoice : MonoBehaviour
{
    public static bool MushDown = false;
    public static bool TentacleDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TyuubetaVoice()
    {
        if(MushDown)
        {
            MushVoice();
        }
        else if(TentacleDown)
        {
            TentacleVoice();
        }
        else if(!MushDown && !TentacleDown)
        {
            BothVoice();
        }
        yield return new WaitForSeconds(5);
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
