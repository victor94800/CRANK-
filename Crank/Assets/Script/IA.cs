using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public float speed;
    public int dmg;

    private RaycastHit hit;
    private RaycastHit hit2;
    private RaycastHit hit3;
    private RaycastHit hit4;
    private RaycastHit hit5;
    CharacterController controller;
    Vector3 movedirection;
    float dailyrotation;
    float changerotation;
    private float newrotation;
    Vector3 dirtomain;
    Transform h;
    Animator anim;
    private bool fight;
    bool follow;
    public bool Attack;
    private int life;
    public GameObject COINS;
    public static Vector3 pos;
    Quaternion rtn;
    int rotation;
    
    void Start()
    {
        follow = false;
        newrotation = Random.Range(0, 361);
        dailyrotation = 2;
        life = 50;
        anim = this.GetComponentInChildren<Animator>();
        anim.SetTime(1);
        fight = false;
        rtn = COINS.transform.rotation;
    }

    
    void Update()
    {
        h = GameObject.Find("Player").transform;
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
        if (dirtomain.magnitude < 0.01f)
        {
            
            transform.position = Vector3.Lerp(transform.position, h.position, 0.05f);
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
        else
        {

           
            movedirection = Vector3.forward * speed;
            movedirection = transform.TransformDirection(movedirection);
            transform.Translate(new Vector3(0, 0, 0.1f));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,newrotation,0), 0.5f * Time.deltaTime);
        }

        if (life <= 0)
        {
          
            
            rotation = Random.Range(2, 7);
            for (int i = 0; i < rotation; i++)
            {
               
                pos = Random.insideUnitSphere * 5 + this.gameObject.transform.position;
                Transform newGameObj = Instantiate(COINS.transform, pos, rtn) as Transform;
            }
            
            
            this.gameObject.SetActive(false);
         
            
        }
        
        anim.SetBool("Attack", Attack);

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.name != "TerrainMain")
        {
            transform.Rotate(new Vector3(0, 90, 0));
        }
        
    }


    private void getHit(int nb)
    {
     
        life -= nb;
        
    }
}
