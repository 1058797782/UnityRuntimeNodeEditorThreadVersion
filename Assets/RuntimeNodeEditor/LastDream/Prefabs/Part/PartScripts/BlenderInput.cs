using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using RuntimeNodeEditor;

/// <summary>
/// UI预制件：类Blender式数值输入框
/// </summary>
public class BlenderInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text TextView;
    public Button btnLeft;
    public Button btnRight;
    public BlenderInputType inputType;
    public Node NodeClass;
    /// <summary>
    /// 输入框的参数名，如X
    /// </summary>
    public string inputName;

    private GameObject textArea;
    private float addNum = 0.1f;

    //private bool _disableMouseDrag;//防止输入状态时，也可进行拖曳的内部判定变量
    //public bool DisableMouseDrag { get { return _disableMouseDrag; } }
    private void Start()
    {
        textArea = inputField.transform.Find("Text Area").gameObject;

        inputField.onSelect.AddListener(OnSelectEvent);
        inputField.onEndEdit.AddListener(OnEndEditEvent);

        //角标左减值
        btnLeft.onClick.AddListener(() =>
        {
            float num = float.Parse(inputField.text);
            inputField.text = (num - addNum).ToString();
        });
        //角标右加值
        btnRight.onClick.AddListener(() =>
        {
            float num = float.Parse(inputField.text);
            inputField.text = (num + addNum).ToString();
        });

        //数值属性名显示
        if (inputName != null && inputName != "")
        {
            TextView.text = inputName;
        }
        //inputField.interactable = false;
    }

    /// <summary>
    /// 结束输入
    /// </summary>
    /// <param name="arg0"></param>
    private void OnEndEditEvent(string arg0)
    {
        //恢复角标按钮显示
        //print("输入框结束编辑：" + arg0);
        btnLeft.interactable = true;
        btnRight.interactable = true;
        TextView.gameObject.SetActive(true);

        //恢复内容居中对齐
        //_disableMouseDrag = false;
        textArea.GetComponentInChildren<TextMeshProUGUI>().alignment = TextAlignmentOptions.MidlineRight;
        //inputField.interactable = false;
        //四舍五入三位小数
        inputField.text = Math.Round(float.Parse(inputField.text == "" ? "0" : inputField.text), 3).ToString();
    }

    /// <summary>
    /// 选中输入
    /// </summary>
    /// <param name="arg0"></param>
    private void OnSelectEvent(string arg0)
    {
        //输入框点击后隐藏角标按钮
        //print("输入框被点击：" + arg0);
        btnLeft.interactable = false;
        btnRight.interactable = false;
        TextView.gameObject.SetActive(false);

        //内容左对齐
        //_disableMouseDrag = true;
        textArea.GetComponentInChildren<TextMeshProUGUI>().alignment = TextAlignmentOptions.MidlineLeft;
        //inputField.interactable = true;
    }

    /// <summary>
    /// 数值类型
    /// </summary>
    public enum BlenderInputType
    {
        Int, Float
    }

}
