using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog Data", menuName = "MouseTool/Dialog Data")]
public class DialogSTOBJ : ScriptableObject
{
    [TextArea]
    public string DialogData;
}
