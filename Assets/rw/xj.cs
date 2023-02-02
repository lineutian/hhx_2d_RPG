using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//¿ØÖÆÏà»ú¸úËæ
public class xj : MonoBehaviour
{
    public Transform target;
    public float smoonthing;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void LateUpdate()
    {
        if(target !=null)
        {
            if(transform.position !=target.position)
            {
                Vector2 targetPos = target.position;
                transform.position = Vector2.Lerp(transform.position, targetPos, smoonthing);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
