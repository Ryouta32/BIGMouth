using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixAccess : MonoBehaviour
{
	Texture2D drawTexture;
	Color[] buffer;
	Texture2D mainTexture;

	void Start()
	{
		mainTexture = (Texture2D)GetComponent<Renderer>().material.mainTexture;
		Color[] pixels = mainTexture.GetPixels();

		buffer = new Color[pixels.Length];
		pixels.CopyTo(buffer, 0);

		drawTexture = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
		drawTexture.filterMode = FilterMode.Point;
	}

	public void Draw(Vector2 p)
	{
		for (int x = 0; x < drawTexture.width; x++)
		{
			for (int y = 0; y < drawTexture.height; y++)
			{
				if ((p - new Vector2(x, y)).magnitude < 5)
				{
					buffer.SetValue(Color.black, x + mainTexture.width * y);
				}
			}
		}
	}
	public void Draw2(Vector2 p)
	{
		Color color = new Color(1f, 1f, 1f, 0f);
		for (int x = 0; x < drawTexture.width; x++)
		{
			for (int y = 0; y < drawTexture.height; y++)
			{
				if ((p - new Vector2(x, y)).magnitude < 5)
				{
					buffer.SetValue(color, x + mainTexture.width * y);
				}
			}
		}
	}

	void Check()
	{
		var pixels = drawTexture.GetPixels(0, 0, drawTexture.width, drawTexture.height);
		int count = 0;      // ピクセルのアルファ値が0(透明)のピクセル数を格納

		foreach (var pixel in pixels)
		{
			if (pixel.a == 0f)
			{
				count++;
			}
		}
		var pixelTexture = pixels.Length / pixels.Length;           // テクスチャのサイズを1とする
		var pixelAlpha = (float)count / (float)pixels.Length;       // 透明に塗られたピクセル数を0から1までの範囲で求める

		// この時点でテクスチャのピクセルに対して透過にした割合を0から1までの範囲で設定できていますが
		// UIの表示用に値を0から100までの範囲に広げます
		// 
		// 単純に全部透過したかを確認したい場合は以下のようにすれば判定できます
		// if(pixelAlpha >= 1)  { 全部塗った時の処理 }

		var magnification = 100;        // 倍率
		var numPixelTexture = (pixelTexture * magnification);           // テクスチャのサイズを100にする
		var numPixelAlpha = (pixelAlpha * magnification);               // 透過率を0から100までの範囲にする
		if (numPixelAlpha >= 100f)
		{
			Debug.Log("掃除完了");
		}

		string text = $"{numPixelAlpha.ToString("N2")} / {numPixelTexture.ToString("N2")}";
		//mRegionText.SetText(text);      // テキストUIに値を設定

	}
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100.0f))
			{
				var vec = new Vector2(hit.textureCoord.x * mainTexture.width, hit.textureCoord.y * mainTexture.height);
				Draw(vec);
			}

			drawTexture.SetPixels(buffer);
			drawTexture.Apply();
			GetComponent<Renderer>().material.mainTexture = drawTexture;
		}
		if (Input.GetMouseButton(1))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100.0f))
			{
				var vec = new Vector2(hit.textureCoord.x * mainTexture.width, hit.textureCoord.y * mainTexture.height);
				Draw2(vec);
			}

			drawTexture.SetPixels(buffer);
			drawTexture.Apply();
			GetComponent<Renderer>().material.mainTexture = drawTexture;
		}
	}
}
