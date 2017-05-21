using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{

    public float speed;
    
	// atribut de l'IA
	public int life;
	public int Damage;
	public Vector3 pos;
	public bool Attack;
	bool follow;
	public int gravity;

	// atribut relatif au deplacement de l'ia 
    Vector3 movedirection;
    float dailyrotation;
    float changerotation;
    private float newrotation;
    
    // animation de l'ia
    Animator anim;
   
    
    

	// gameobject utilisés par l'ia 
	public GameObject COINS;
	Quaternion rtn;

	// player information
	Vector3 dirtomain; // distance entre l'ia et le joueur
	Transform pt;

	CharacterController cc;

	Vector3 mouvedirection; 

    void Start()
    {
		// aniamtion 
		/*anim = this.GetComponentInChildren<Animator>();
		anim.SetTime(1);

		// initialistation des deplacements 
		follow = false;
        newrotation = Random.Range(0, 361);
        dailyrotation = 2;*/


		cc = GetComponent<CharacterController>();
        
       
        // intitailistaton des attribut ou des objets utilisés par l'IA 
        rtn = COINS.transform.rotation;
    }

    
    void Update()
    {
		//mouvedirection = Vector3.zero;
		mouvedirection = Vector3.forward * speed;
		mouvedirection = transform.TransformDirection(mouvedirection);
		// update des attribut de deplacements 
		pt = GameObject.Find("Player").transform;
        dirtomain = GameObject.Find("Player").transform.position - transform.position;
        newrotation = Random.Range(0, 361);
        
       
        
      
       
       // rayon detection des objetes a l'aide rayon projeter a partire d'un empty de l'enemy;
       /* if (Physics.Raycast(transform.Find("origin").position,new Vector3(0, -45, 0) , 10f))
        {
            if (hit1.distance < 5 )
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), 0.5f * Time.deltaTime);
            }
        }

        Debug.DrawRay(transform.Find("origin").position, transform.forward, Color.red, 1);*/
        if (follow == true )// deplacement en suivant le joueur 
        {
            
            transform.position = Vector3.Lerp(transform.position, pt.position, 0.05f);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtomain), 10f);
            if (dirtomain.magnitude < 1.5) 
            {
                Attack = true;
            }
            else 
            {
                Attack = false;
            }
        }
        else // deplacements aleatoire 
        {

           
            
           // movedirection = transform.TransformDirection(movedirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,newrotation,0), 0.5f * Time.deltaTime);
        }
		// verifie si l'ia est toujour en vie 
        if (life <= 0)
        {


			int nbcoins = Random.Range(2, 7);
			for (int i = 0; i < nbcoins; i++)
			{
               
                pos = Random.insideUnitSphere * 5 + this.gameObject.transform.position;
                Transform newGameObj = Instantiate(COINS.transform, pos, rtn) as Transform;
            }
            
            
            this.gameObject.SetActive(false);
         
            
        }
	// action de l'ia or deplacements 

        // fait attaque ou non l'ia 
        anim.SetBool("Attack", Attack);
		mouvedirection.y -= gravity * Time.deltaTime;
		cc.Move(mouvedirection * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.name != "TerrainMain")
        {
            transform.Rotate(new Vector3(0, 90, 0));
        }
        
        
    }
	// verifie si l'ia doit suivre ou non je joueur 
	private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
        {
            follow = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.name == "Player")
        {
            follow = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        follow = false;
    }
	// inflige des domages a l'ia 
	private void getHit(int nb)
    {
     
        life -= nb;
        
    }
}
