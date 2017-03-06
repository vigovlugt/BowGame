using UnityEngine;
public class Util{
public static void SetLayerRecursively(GameObject obj, string newLayer)
    {
        if (null == obj)
        {
            return;
        }
        
        obj.layer = LayerMask.NameToLayer(newLayer);
       
        foreach (Transform child in obj.transform)
        {
            if (null == child)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }


}