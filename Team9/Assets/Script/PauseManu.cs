using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManu : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;
    [SerializeField]
    private Button Exit;

    [SerializeField]
    private Button Title;

    [SerializeField]
    private Button ReStart;

   
    //現在セーブ中か？
    public static bool pausing;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManuSelect();
    }
    void ManuSelect()
    {
        // ポーズ状態が変更されていたら、Pause/Resumeを呼び出す。
        if (Input.GetKeyDown("joystick button 7") && pausing == false)
        {
            pausing = true;



            Time.timeScale = 1f;
            Panel.SetActive(true);
            Exit.gameObject.SetActive(true);
            Title.gameObject.SetActive(true);
            ReStart.gameObject.SetActive(true);

        }
        else if (Input.GetKeyDown("joystick button 7") && pausing == true)
        {
   
  
            pausing = false;
            Time.timeScale = 1f;
            Panel.SetActive(false);
            Exit.gameObject.SetActive(false);
            Title.gameObject.SetActive(false);
            ReStart.gameObject.SetActive(false);
        }
    }
}
