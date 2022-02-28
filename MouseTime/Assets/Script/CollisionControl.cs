using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    public playerController t;
    void Start()
    {
        t = this.gameObject.transform.parent.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "enemy"&& playerController.isAlive)
        {
            playerController.isAlive = false;
            Debug.Log("死了");
        }
        Debug.Log("死了但是没完全死");
    }

    void OnTriggerStay2D(Collider2D Collider)
    {
        if(Collider.gameObject.name== "DiaLog")
        {

            t.Dialog(Collider,true);
            
        }
    }
    void OnTriggerExit2D(Collider2D Collider)
    {
        if (Collider.gameObject.name == "DiaLog")
        {


            t.Dialog(Collider,false);
        }
    }
}
