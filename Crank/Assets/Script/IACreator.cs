using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACreator : MonoBehaviour {
    public GameObject IA;
    public static Vector3 pos;
    Quaternion rtn;
    private int rotation;
    
   
    // Use this for initialization
    void Start ()
    {
		pos = Random.insideUnitSphere * 10 + new Vector3 (100,50,300);
        rtn = IA.transform.rotation;
        rotation = Random.Range(5, 20);
        for (int i = 0; i < rotation; i++)
        {

            
            
            Transform newGameObj = Instantiate(IA.transform, pos, rtn) as Transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
