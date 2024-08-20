using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaSpawn : MonoBehaviour
{
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] float time = 5.0f;

    Vector3 objectSize;
    float x, z;

    // Start is called before the first frame update
    void Start()
    {
        //OVRSceneRoom sceneRoom = FindAnyObjectByType<OVRSceneRoom>();
        //OVRScenePlane floor = sceneRoom.Floor;

        // �I�u�W�F�N�g��Renderer�R���|�[�l���g���擾
        Renderer renderer = GetComponent<Renderer>();

        // �I�u�W�F�N�g�̃T�C�Y���擾
        objectSize = renderer.bounds.size;

        // �T�C�Y�����O�ɏo��
        //Debug.Log("Object Size: " + objectSize);

        x = objectSize.x / 2;
        z = objectSize.z / 2;

        // time�b���Ƃ�Spawn�Ăяo��
        InvokeRepeating(nameof(Spawn), 1, time);

        Debug.Log("x:" + x + "z:" + z);
    }

    void Spawn()
    {
        // �p�x�����_������
        int rnd = Random.Range(0, 360);
        Instantiate(spawnPrefab, new Vector3(x, 1, z), Quaternion.Euler(0, rnd, 0));
    }
}
