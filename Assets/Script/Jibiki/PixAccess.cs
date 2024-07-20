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
		int count = 0;      // �s�N�Z���̃A���t�@�l��0(����)�̃s�N�Z�������i�[

		foreach (var pixel in pixels)
		{
			if (pixel.a == 0f)
			{
				count++;
			}
		}
		var pixelTexture = pixels.Length / pixels.Length;           // �e�N�X�`���̃T�C�Y��1�Ƃ���
		var pixelAlpha = (float)count / (float)pixels.Length;       // �����ɓh��ꂽ�s�N�Z������0����1�܂ł͈̔͂ŋ��߂�

		// ���̎��_�Ńe�N�X�`���̃s�N�Z���ɑ΂��ē��߂ɂ���������0����1�܂ł͈̔͂Őݒ�ł��Ă��܂���
		// UI�̕\���p�ɒl��0����100�܂ł͈̔͂ɍL���܂�
		// 
		// �P���ɑS�����߂��������m�F�������ꍇ�͈ȉ��̂悤�ɂ���Δ���ł��܂�
		// if(pixelAlpha >= 1)  { �S���h�������̏��� }

		var magnification = 100;        // �{��
		var numPixelTexture = (pixelTexture * magnification);           // �e�N�X�`���̃T�C�Y��100�ɂ���
		var numPixelAlpha = (pixelAlpha * magnification);               // ���ߗ���0����100�܂ł͈̔͂ɂ���
		if (numPixelAlpha >= 100f)
		{
			Debug.Log("�|������");
		}

		string text = $"{numPixelAlpha.ToString("N2")} / {numPixelTexture.ToString("N2")}";
		//mRegionText.SetText(text);      // �e�L�X�gUI�ɒl��ݒ�

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
