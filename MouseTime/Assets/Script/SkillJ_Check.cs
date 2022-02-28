using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillJ_Check : MonoBehaviour
{
    public GameObject MyMouse;
    
    public playerController t;

    public GameObject target;

    void Start()
    {
        MyMouse = this.transform.parent.gameObject;
        t = MyMouse.transform.parent.GetComponent<playerController>();
        
    }
  


    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name !=MyMouse.name )
        {
           
            target = MyMouse.transform.parent.transform.Find(collision.name).transform.gameObject;
            t.MyMouse = target;
            
            
        }    
    }


}
