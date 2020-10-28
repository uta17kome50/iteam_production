using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
 

    // Start is called before the first frame update
    void Start()
    {
        
        FadeManager.FadeIn();
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene();
    }

    void Scene()
    {
        if(Input.GetKeyDown("k"))
        {
            FadeManager.FadeOut("koyama");
        }
    }
}
