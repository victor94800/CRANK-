using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Screen_Shot_test2 : MonoBehaviour {
	public Camera cam;
	public int height;
	static int nb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
		{
			Texture2D Y = TakeScreenShot( cam , new Bounds());
			
			save(Y);
			
		}
	}
	public Texture2D TakeScreenShot(Camera camera, Bounds bound)
	{
//#if UNITY_ANDROID
            Texture2D snapShot = new Texture2D((int)camera.pixelWidth  , (int)camera.pixelHeight , TextureFormat.RGB24, false );
            snapShot.ReadPixels( new Rect( camera.pixelRect.xMin, camera.pixelRect.xMin-height, (int)camera.pixelWidth  , (int)camera.pixelHeight ), 0, 0, false );
            snapShot.Apply();
            return snapShot;
/*#endif
		return new Texture2D(100, 100);*/
	}
	public void save(Texture2D y)
	{
		byte[] bytes = y.EncodeToPNG();
		//Object.Destroy(screenCap);
		print(Application.dataPath);
		// For testing purposes, also write to a file in the project folder
		File.WriteAllBytes(Application.dataPath + "/SavedScreen" + nb + ".png" , bytes);
		nb += 1;

		
	}
}
