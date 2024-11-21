using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixelData : MonoBehaviour
{
    //[SerializeField] Text text;
    //[SerializeField] Image image;

    Texture2D tex;
    Material material;
    //MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;

        //if (meshRenderer == null)
        //{
        //    Debug.LogError("MeshRenderer is not attached to the GameObject");
        //}
        foreach (string propertyName in material.GetTexturePropertyNames())
        {
            Debug.Log($"Property Name: {propertyName}");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Wall")
        {
            Vector3 pos = collision.contacts[0].point;  // 衝突点を取得
            tex = material.GetTexture("_BaseMap") as Texture2D;

            if (tex == null)
            {
                Debug.LogError("MainTexture is either null or not a Texture2D. Ensure that the texture is readable and the correct property name is used.");
                return;
            }

            RaycastHit hit;
            if (Physics.Raycast(pos, -collision.contacts[0].normal, out hit, Mathf.Infinity))  // 法線の逆方向にレイを飛ばす
            {
                Vector2 uv = hit.textureCoord;
                int x = Mathf.FloorToInt(uv.x * tex.width);
                int y = Mathf.FloorToInt(uv.y * tex.height);

                if (x >= 0 && x < tex.width && y >= 0 && y < tex.height)  // 範囲内であることを確認
                {
                    Color[] pix = tex.GetPixels(x, y, 1, 1);
                    Debug.Log(pix[0]);
                }
                else
                {
                    Debug.LogWarning("UV coordinates out of texture bounds.");
                }
            }
            else
            {
                Debug.LogWarning("Raycast did not hit any collider.");
            }
        }
    }
}