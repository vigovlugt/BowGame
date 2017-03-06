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


public static void DestroyChildren(GameObject obj, string _tag){

    foreach (Transform child in obj.transform)
        {
            if(child.tag == _tag){
                GameObject.Destroy(child.gameObject);
            }
            DestroyChildren(child.gameObject, _tag);
        }


}

}