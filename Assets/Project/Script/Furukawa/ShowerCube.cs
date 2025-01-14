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
    private void OnCollisionEnter(Collision col)
    {
        PaintManager paintManager = new PaintManager();


        if (col.gameObject.CompareTag("yokokabe"))
        {
            pieceManager = col.transform.parent.GetComponent<PieceManager>();

            //ここに壁を修復するやつかく当たったタグがよこかべだったら当たったオブジェクトのメッシュレンダラーを表示
            if (col.gameObject.transform.childCount == 0)
            {
                GameObject clone = Instantiate(col.gameObject, col.gameObject.transform.position, col.transform.rotation);
                clone.GetComponent<MeshRenderer>().material = m;

                MeshCollider meshcol = clone.GetComponent<MeshCollider>();
                meshcol.convex = true;
                meshcol.isTrigger = true;
                clone.transform.parent = col.transform;
                clone.tag = "Untagged";
                clone.transform.localScale = new Vector3(1, 1, 1);
                pieceManager.AddItem(clone.transform);
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
    private void OnTriggerEnter(Collider col)
    {
        PaintManager paintManager = new PaintManager();
        if (col.gameObject.GetComponent<InkCanvas>())
        {
            switch (col.transform.tag)
            {
                case "Dragon":
                    paintManager.Paint(col, useMethodType, !erase, brush, transform, true, col.transform.tag);
                    break;
                case "Wall":
                    paintManager.Paint(col, useMethodType, erase, brush, transform, false, col.transform.tag);
                    Destroy(gameObject);
                    break;
                //ここに壁を修復するやつかく当たったタグがよこかべだったら当たったオブジェクトのメッシュレンダラーを表示
                case "yokokabe":
                    GameObject clone = Instantiate(col.gameObject, col.gameObject.transform.position, Quaternion.identity);
                    clone.GetComponent<MeshRenderer>().material = m;
                    //pieceManager.PieceChildren.Add(clone.transform); // GetChild()で子オブジェクトを取得
                    break;
            }
        }
    }
}
