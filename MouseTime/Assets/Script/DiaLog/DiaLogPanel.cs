using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiaLogPanel : MonoBehaviour
{
    public Collider2D target;
    public float Xpy;
    public float Ypy;
    private GameObject bg;
    private RectTransform t;
    private DialogSTOBJ DialogData1;
    private Text text;
    void Start()
    {
        bg = this.transform.Find("bg").gameObject;
        t = bg.GetComponent<RectTransform>();
    }

    void Update()
    {
        if(target!=null)
            Movecrl();
    }

    private void Movecrl()
    {
        t.anchoredPosition = new Vector2(Camera.main.WorldToScreenPoint(target.transform.gameObject.transform.position).x + Xpy, Camera.main.WorldToScreenPoint(target.transform.gameObject.transform.position).y + Ypy);
        DialogData1 = target.gameObject.GetComponent<DiaLogSave>().dialogdata;
        text = this.transform.Find("bg/Text").GetComponent<Text>();
        text.text = DialogData1.DialogData;
    }
}
