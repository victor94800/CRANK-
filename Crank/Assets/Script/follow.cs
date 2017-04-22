using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
    private Transform Target;
	public GameObject target;
    Vector3 dirtomain;
	public int high = 1;
	public bool lookat = true;
	public float speed_follow = 10f;
	public float distance;
	public bool following;
	public int x = 1;
	public int y = 1 ;
	public int z = 1;
	public bool following_under_distance;
    // Use this for initialization
    void Start () {
        Target = target.transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
		dirtomain = target.transform.position - transform.position;
		


		if (following_under_distance)
		{
			if (dirtomain.magnitude > distance || dirtomain.magnitude < distance - 3)
			{
				transform.position = dirtomain + new Vector3(0, 0, distance);
			}
			if (lookat)
			{
				transform.LookAt(target.transform);
				//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), speed_follow);
			}
		}
		else
		{


			if (following)
			{
				
					
						//transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y + high, Target.transform.position.z);
						if (lookat)
						{
							transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), speed_follow);
						}
				        transform.position = new Vector3(Target.transform.position.x * x, Target.transform.position.y + high * y, Target.transform.position.z - distance * z);
			}
			else
			{
				if (Target.transform.position != transform.position)
				{
					//transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y + high, Target.transform.position.z);
					if (lookat)
					{
						transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), speed_follow);
					}
				}
			}
		}
	}
}
