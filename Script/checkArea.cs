using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("shootarea")) // 检查触发器所属的特定区域标签
        {
            uiscore.shoot=5;
            uiscore.isinarea=true;
            Debug.Log("在特定区域内");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("shootarea")) // 检查触发器所属的特定区域标签
        {
            uiscore.isinarea=false;
            uiscore.shoot=0;
            Debug.Log("离开特定区域");
        }
    }

}
