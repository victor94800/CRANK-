using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACreator : MonoBehaviour
{
   
   
   public GameObject Not_moving_IA;
   public GameObject Following_Path_IA;
   public GameObject Random_moving_IA;
   public GameObject[] IA_Type;

	public GameObject InstentiateIA(int type, Quaternion rotation, GameObject T = null ,  GameObject[] target = null)
	{
		GameObject IA;
		if (T == null)
		{
			 IA = Instantiate(Following_Path_IA, target[0].transform.position, rotation);
		}
		else
		{
			 IA = Instantiate(T, target[0].transform.position, rotation);
		}
		
		/*switch (type)
		{
			case 0:

				ParcourIA l = new ParcourIA();
				l = IA.GetComponent<ParcourIA>();
				l.target = target;
				break;
			case 1:
				notMovingIA L = new notMovingIA();
			
				L = IA.GetComponent<notMovingIA>();
				
				break;
			case 2:
				IA h = new IA();
				h = IA.GetComponent<IA>();
				

				break;
			default:
				break;

		}*/
		return IA;
	}
}
