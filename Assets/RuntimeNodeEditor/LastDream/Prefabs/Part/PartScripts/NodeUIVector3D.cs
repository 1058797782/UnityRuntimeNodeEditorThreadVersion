using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RuntimeNodeEditor;

/// <summary>
/// UI预制件集合：Vector3XYZ对象数值的更新修改
/// </summary>
public class NodeUIVector3D : MonoBehaviour
{
    public BlenderInput inputX;
    public BlenderInput inputY;
    public BlenderInput inputZ;

    public Node NodeClass;

    /// <summary>
    /// 手动修改数值监听
    /// </summary>
    public Action<inputType,string> AnyInputfieldValueChangedListener;

    private void Start()
    {
        //手动修改数值监听
        inputX.inputField.onValueChanged.AddListener((string str)=> {
            AnyInputfieldValueChangedListener?.Invoke(inputType.X,str);
        });
        inputY.inputField.onValueChanged.AddListener((string str) => {
            AnyInputfieldValueChangedListener?.Invoke(inputType.Y, str);
        });
        inputZ.inputField.onValueChanged.AddListener((string str) => {
            AnyInputfieldValueChangedListener?.Invoke(inputType.Z, str);
        });

        inputX.NodeClass = inputY.NodeClass = inputZ.NodeClass = this.NodeClass;
    }

    public Vector3 GetVector3()
    {
        Vector3 vector3 = new Vector3();
        vector3.x = float.Parse(inputX.inputField.text == "" ? "0" : inputX.inputField.text);
        vector3.y = float.Parse(inputY.inputField.text == "" ? "0" : inputY.inputField.text);
        vector3.z = float.Parse(inputZ.inputField.text == "" ? "0" : inputZ.inputField.text);
        return vector3;
    }

    /// <summary>
    /// no listener event
    /// </summary>
    /// <param name="vector3"></param>
    public void SetVector3(Vector3 vector3)
    {
        // 四舍五入到两位小数
        float roundedX = Mathf.Round(vector3.x * 100f) / 100f;
        float roundedY = Mathf.Round(vector3.y * 100f) / 100f;
        float roundedZ = Mathf.Round(vector3.z * 100f) / 100f;

        // 将四舍五入后的值转换为字符串并设置文本
        inputX.inputField.SetTextWithoutNotify(roundedX.ToString("F2"));
        inputY.inputField.SetTextWithoutNotify(roundedY.ToString("F2"));
        inputZ.inputField.SetTextWithoutNotify(roundedZ.ToString("F2"));
    }

    public enum inputType 
    { 
        X,Y,Z
    }
}
