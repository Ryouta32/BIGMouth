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
    private void Update()
    {
        transform.localPosition =new Vector3(0,0,0) ;
        transform.localEulerAngles = new Vector3(0, 0, 0);
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
        if (obj.name == "TentacleBeta")
            Instantiate(obj, EnemyManager.tentPos, Quaternion.identity);

        if (obj.name == "Mash")
            Instantiate(obj, EnemyManager.tentPos, Quaternion.identity);
    }
    public void Erase() => erase = true;
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
