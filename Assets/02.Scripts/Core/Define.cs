using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Define 
{
    public static bool ExistInHits(GameObject obj, object hits)
    {
        if (hits == null || !(hits is List<RaycastResult>))
        {
            Debug.LogError("Hits�� null�̰ų� Ÿ���� ���� �ʽ��ϴ�");
            return true;
        }

        foreach (RaycastResult hit in hits as List<RaycastResult>)
        {
            if (hit.gameObject == obj && (obj.transform.IsChildOf(hit.gameObject.transform) || hit.gameObject.transform.IsChildOf(obj.transform)))
            {
                return true;
            }
        }

        return false;
    }

    public static bool ExistInFirstHits(GameObject obj, object hits)
    {
        if (hits == null || !(hits is List<RaycastResult>))
        {
            Debug.LogError("Hits�� null�̰ų� Ÿ���� ���� �ʽ��ϴ�");
            return true;
        }

        List<RaycastResult> rayList = hits as List<RaycastResult>;

        if (rayList.Count == 0)
        {
            return false;
        }

        RaycastResult hit = rayList[0];
        if (obj.transform.IsChildOf(hit.gameObject.transform) || hit.gameObject.transform.IsChildOf(obj.transform))
        {
            return true;
        }
        return false;
    }
}
