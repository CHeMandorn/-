using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public float smothing = 5f;
    public float zbj;
    public float ybj;
    Vector3 offset;
    public GameObject control;


     
    void Start()
    {

        offset = transform.position - target.position;
        
    }

    void FixedUpdate()
    {
        if (control.GetComponent<playerController>().MyMouse.transform != target)
            target = control.GetComponent<playerController>().MyMouse.transform;

        if (this.gameObject.transform.position.x <= ybj || this.gameObject.transform.position.x>=zbj)
        {

            Vector3 targetCampos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCampos, smothing * Time.deltaTime);//摄像机自身位置到目标位置
        }
        if (this.gameObject.transform.position.x > ybj)
        {
            Vector3 you = new Vector3();
            you.x = ybj;
            you.y = this.gameObject.transform.position.y;
            you.z = this.gameObject.transform.position.z;
            transform.position = you;
        }

        if (this.gameObject.transform.position.x <zbj)
        {
            Vector3 you = new Vector3();
            you.x = zbj;
            you.y = this.gameObject.transform.position.y;
            you.z = this.gameObject.transform.position.z;
            transform.position = you;
        }


    }
        

}
