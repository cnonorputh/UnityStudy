using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using static UnityEditor.ShaderData;
using System.Threading.Tasks;

public static class UniTaskTest 
{
    public static async UniTask Test(Transform _trans)
    {
        //����ǰ�����ӵ����̳�������
        await UniTask.SwitchToTaskPool();
        //await UniTask.Yield();
        //�ӳ�s���У��Ὣ��������������߳�֮��
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        //ת�ص����߳�֮�н�������
        await UniTask.SwitchToMainThread();
        _trans.position = new Vector3(1, 1, 1);
        
    }

    public static void StartUnitask(float delayTime,AnyFunction function)
    {
        if(function != null)
        {
            DelaytUnitask(delayTime, function);
        }
    }
    private static async Task DelaytUnitask(float delayTime, AnyFunction function)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(delayTime));
        function?.Invoke();
    }
}

public delegate void AnyFunction();