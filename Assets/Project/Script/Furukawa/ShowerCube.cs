using Es.InkPainter;
using UnityEngine;
using static PaintManager;

public class ShowerCube : MonoBehaviour
{
    [SerializeField]
    private Brush brush;
    [SerializeField]
    private Brush draBrush;

    [SerializeField]
    private PaintManager.UseMethodType useMethodType;

    [SerializeField]
    bool erase = false;
    [SerializeField] string DragonTag = "Dragon";

    [SerializeField] Material m;
    PieceManager pieceManager;

    Animator anim;

    private void OnCollisionEnter(Collision col)
    {
        PaintManager paintManager = new PaintManager();


        if (col.gameObject.CompareTag("yokokabe"))
        {
            if (col.transform.parent.GetComponent<PieceManager>())
            {
                pieceManager = col.transform.parent.GetComponent<PieceManager>();

                //ここに壁を修復するやつかく当たったタグがよこかべだったら当たったオブジェクトのメッシュレンダラーを表示
                if (col.gameObject.transform.childCount == 0)
                {
                    GameObject clone = Instantiate(col.gameObject, col.gameObject.transform.position, col.transform.rotation);
                    clone.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                    //ここにアニメーション再生
                    //Rigidbody rb = clone.AddComponent<Rigidbody>();
                    //rb.useGravity = false;
                    anim = clone.AddComponent<Animator>();
                    anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Scale");
                    if (anim.runtimeAnimatorController == null)
                    {
                        //Debug.Log("ないーーーーーー");
                    }
                    clone.GetComponent<MeshRenderer>().material = m;

                    MeshCollider meshcol = clone.GetComponent<MeshCollider>();
                    meshcol.convex = true;
                    meshcol.isTrigger = true;
                    clone.transform.parent = col.transform;
                    clone.tag = "Untagged";
                    if (pieceManager != null)
                    {
                        pieceManager.AddItem(clone.transform);
                        pieceManager.CountStart();
                    }
                    HPManager.time -= 1;
                    HPManager.hpPiece += 1;
                }
            }
                if (col.transform.parent.GetComponent<TutorialPieceManager>())
                {
                    //ここに壁を修復するやつかく当たったタグがよこかべだったら当たったオブジェクトのメッシュレンダラーを表示
                    if (col.gameObject.transform.childCount == 0)
                    {
                        GameObject clone = Instantiate(col.gameObject, col.gameObject.transform.position, col.transform.rotation);
                        clone.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                        //ここにアニメーション再生
                        //Rigidbody rb = clone.AddComponent<Rigidbody>();
                        //rb.useGravity = false;
                        anim = clone.AddComponent<Animator>();
                        anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Scale");
                        if (anim.runtimeAnimatorController == null)
                        {
                            //Debug.Log("ないーーーーーー");
                        }
                        clone.GetComponent<MeshRenderer>().material = m;

                        MeshCollider meshcol = clone.GetComponent<MeshCollider>();
                        meshcol.convex = true;
                        meshcol.isTrigger = true;
                        clone.transform.parent = col.transform;
                        clone.tag = "Untagged";
                        HPManager.time -= 2;
                        HPManager.hpPiece += 1;
                    }
                }

            }
            if (col.gameObject.GetComponent<InkCanvas>())
            {
                switch (col.transform.tag)
                {
                    case "Dragon":
                        paintManager.Paint(col, useMethodType, !erase, brush, transform, true, col.transform.tag);
                        break;
                    case "Wall":
                        paintManager.Paint(col, useMethodType, erase, brush, transform, false, col.transform.tag);
                        break;
                }

                Destroy(gameObject);
            }
        }
    }
