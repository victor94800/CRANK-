using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobShop : MonoBehaviour {
    public int money;
    public bool ISfireswordallowed;
    public bool isthunderswordallowed;
    public bool isdoublejumpallowed;
    // Use this for initialization
    void Start()
    {
        money = 100;
        ISfireswordallowed = false;
        isthunderswordallowed = false;
        isdoublejumpallowed = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
