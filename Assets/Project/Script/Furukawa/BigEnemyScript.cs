using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigEnemyScript : MonoBehaviour
{
    [SerializeField] List<GameObject> weekPoints;
    [Tooltip("弱点こする回数")][SerializeField] public int rubCount;
    [Tooltip("弱点から出る汚れの数")][SerializeField] public int dirtCount;
    [Tooltip("何回消せばよいか")][SerializeField] public int erasedCount;
    [SerializeField] EnemyData _data;
    [SerializeField] GameObject Tentacle;
    [SerializeField] GameObject Mash;
    [SerializeField] BIGEnemyAnima anima;
    private EnemyData data;
    private bool erase;
    private void Start()
    {
        data = new EnemyData(_data);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (erase)
        {
            if (collision.gameObject.tag == "Brush")
            {
                    data.sutnCount--;
                    if (data.sutnCount <= 0)
                    {
                        //クリア演出
                        SceneManager.LoadScene("ClereScene");
                    }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (erase)
        {
            if (other.gameObject.tag == "Brush")
            {
                data.sutnCount--;
                if (data.sutnCount <= 0)
                {
                    //クリア演出
                    SceneManager.LoadScene("ClereScene");
                }
            }
        }
    }
    public void WeekBreak()
    {
        anima.Break();
    }
    public void Spawn(GameObject obj)
    {
    }
    public void OBJScaleUP()
    {
        //erasedCount++;
        //erase = false;

        //StartCoroutine("ScaleUp");

    }
    public void OBJScaleDown()
    {
        //erasedCount--;
        //if (erasedCount == 0)
        //    erase = true;

        //StartCoroutine("ScaleDown");

    }
    //IEnumerator ScaleUp()
    //{
    //    //for (float i = 0; i < 0.005f; i += 0.001f)
    //    //{
    //    //    this.transform.localScale = new Vector3(this.transform.localScale.x + i, this.transform.localScale.x+ i, this.transform.localScale.x+ i);
    //    yield return new WaitForSeconds(0.1f);
    //    //}
    //}
    //IEnumerator ScaleDown()
    //{
    //    //for (float i = 0.005f; i > 0; i -= 0.001f)
    //    //{
    //    //    this.transform.localScale = new Vector3(this.transform.localScale.x - i, this.transform.localScale.x - i, this.transform.localScale.x - i);
    //    yield return new WaitForSeconds(0.1f);
    //    //}
    //}
}
