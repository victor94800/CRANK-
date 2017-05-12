using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	public GameObject bullet;
	public float Fire_speed;
	public float distence = 10f;

	public static void fire(GameObject Bullet,Vector3 direction,Transform tr , float speed = 10f ,float Distance = 10f)
	{
		GameObject projectile = Instantiate(Bullet, direction, new Quaternion(0,0,0,0) );
		projectile.GetComponent<Rigidbody>().AddForce(tr.TransformDirection(Vector3.forward * speed));
		Destroy(projectile, Distance);
	}
}
