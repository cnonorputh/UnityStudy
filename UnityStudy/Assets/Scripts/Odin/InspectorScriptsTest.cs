using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Cysharp.Threading.Tasks;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

[TypeInfoBox("odin插件测试")]
public class InspectorScriptsTest : MonoBehaviour
{

    [LabelText("数字"), Range(1, 10), ValueDropdown("GetValue")]
    [ValidateInput("CheckNumber", "", InfoMessageType.Error)]
    public float number;
    [Delayed, PropertyOrder(-1)]
    public int delayValue;
    [DelayedProperty, ShowInInspector, PropertyOrder(-1), PropertySpace]
    public int Delay { get { return delayValue; } set { delayValue = value; } }
    [Required]
    public string Name;
    [Searchable, FoldoutGroup("属性"), FoldoutGroup("属性/列表")]
    public List<int> ints = new List<int> { 0, 1, 1, 2, 2, 3, 3, };

    private IEnumerable<float> GetValue()
    {
        List<float> result = new List<float> { 0f, 1f, 2f };
        return result;
    }

    private bool CheckNumber(float number, ref string errorMessage, ref InfoMessageType? messageType)
    {
        errorMessage = "数字不能为0";
        return number != 0;
        
    }
    [Button()]
    private async void UniTaskUse()
    {
        await UniTaskTest.Test(this.transform);
        UniTaskTest.StartUnitask(1f, () =>
        {
            this.transform.gameObject.SetActive(false);
        });
    }
   
    
}

