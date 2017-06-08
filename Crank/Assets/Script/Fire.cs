using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	
	public float Fire_speed;
	public float distence = 10f;

	public static void fire(GameObject Bullet,Vector3 direction,Transform tr , Quaternion rotation,Vector3 dir, float speed = 10f ,float Distance = 10f)
	{
		GameObject projectile = Instantiate(Bullet, direction, rotation );
		projectile.GetComponent<Rigidbody>().AddForce(tr.TransformDirection(Vector3.forward  * speed));
		Destroy(projectile, Distance);
	}
}
