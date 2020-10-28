using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ManuSelect : MonoBehaviour
{
    [SerializeField]
    private Button Exit;

    [SerializeField]
    private Button Title;

    [SerializeField]
    private Button ReStart;
    [SerializeField]
    private GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {

      
    }
    void OnEnable()
    {
        // 自分を選択状態にする
        Selectable sel = GetComponent<Selectable>();
        sel.Select();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        //名前を取得して分岐
        switch (transform.name)
        {
            case "End":
                End();
                break;
            case "Title":
                TitleButton();
                break;
            case "ReStart":
                Restart();
                break;
            default:
                break;

        }

    }
    public void End()
    {
        Debug.Log("終了");
        Application.Quit();
        //Quit();
        Exit.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
        ReStart.gameObject.SetActive(false);
        Panel.gameObject.SetActive(false);
    }
    
    public void TitleButton()
    {
        Time.timeScale = 1f;
        PauseManu.pausing = false;
        GameManagerScene.isTitle = true;

        Exit.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
        ReStart.gameObject.SetActive(false);
        Panel.gameObject.SetActive(false);
        
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        PauseManu.pausing = false;
        GameManagerScene.isReTurn = true;
        Exit.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
        ReStart.gameObject.SetActive(false);
        Panel.gameObject.SetActive(false);
      
    }
}

