using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pictur_c : MonoBehaviour {
	public Texture2D pic1;
	public Texture2D pic2;
	// Use this for initialization
	void Start ()
	{
		int u = compare(pic1,pic2);
		print(u);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public int compare(Texture2D pic1 , Texture2D pic2)
    {
		int y = 0;
		for (int i = 0; i < pic1.height; i ++)
		{
			for (int j = 0; j < pic1.width; j++)
			{
				if (pic1.GetPixel(i,j) == pic2.GetPixel(i,j))
				{
					y += 1;
				}
			}
		}
		return y;
	}
}
