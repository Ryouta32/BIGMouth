using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*�ǃG���A�z���Ă�����~�~�b�N�I�u�W�F�N�g�\��������*/

public class SetActiveScript : MonoBehaviour
{
    [SerializeField] GameObject mimic;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall1"))
        {
            mimic.SetActive(true);
        }
    }
}
