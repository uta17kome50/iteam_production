using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManagerScene : MonoBehaviour
{
    public static bool isTitle = false;
    public static bool isReTurn = false;

    // Start is called before the first frame update
    void Start()
    {
        FadeManager.FadeIn();
        
    }

    // Update is called once per frame
    void Update()
    {
        title();
        Return();
    }

    void title()
    {
        if(isTitle)
        {
            FadeManager.FadeOut("Title");
            isTitle = false;
            Debug.Log(isTitle);

        }
    }

    void Return()
    {
        if(isReTurn)
        {
            Scene loadScene = SceneManager.GetActiveScene();
            FadeManager.FadeOut(loadScene.name);
            isReTurn = false;
        }
    }
}
