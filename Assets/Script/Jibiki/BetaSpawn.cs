using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaSpawn : MonoBehaviour
{
    [SerializeField] GameObject spawnPrefab;

    Vector3 objectSize;
    float x, z;
    [SerializeField] float time = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating(nameof(Spawn), 1, time);
    }

    // Update is called once per frame
    void Update()
    {
        OVRSceneRoom sceneRoom = FindAnyObjectByType<OVRSceneRoom>();
        OVRScenePlane floor = sceneRoom.Floor;

        // �I�u�W�F�N�g��Renderer�R���|�[�l���g���擾
        Renderer renderer = GetComponent<Renderer>();

        // �I�u�W�F�N�g�̃T�C�Y���擾
        objectSize = renderer.bounds.size;

        // �T�C�Y�����O�ɏo��
        Debug.Log("Object Size: " + objectSize);

        x = objectSize.x / 2;
        z = objectSize.z / 2;

    }

    void Spawn()
    {
        int rnd = Random.Range(0, 360);
        Instantiate(spawnPrefab, new Vector3(0, 2, 0), Quaternion.Euler(0, rnd, 0));
    }
}
