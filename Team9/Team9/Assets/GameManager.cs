using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

using UnityEngine.UI;

public enum GameState
{
    //開始
    KeyInput,//キー入力待ち=プレイヤーターン開始
    PlayerTurn,//プレイヤーの行動中
    EnemyBegin,//エネミーターンの開始
    EnemyTurn,//エネミーの行動中
    TurnEnd,//ターン終了→KeyInputへ変遷
}

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject[] EnemyObj; //エネミーにアタッチしている関数を使うためのハコ
    public GameState CurrentGameState; //現在のゲーム状態
    float TurnDelay = 0.20f; //移動ごとの間隔

    public GameObject turnobject;

    public int turn;

    // Start is called before the first frame update
    void Awake()
    {
        Text turn1 = turnobject.GetComponent<Text>();
        turn1.text = "turn" + turn;
        SetCurrentState(GameState.KeyInput); //初期状態はキー入力待ち

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    //源氏のゲームステータスを変更する関数　外部及び内部から

    public void SetCurrentState(GameState state)
    {
        CurrentGameState = state;
        OnGameStateChanged(CurrentGameState);
    }

    // Update is called once per frame
    void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.KeyInput:
                break;

            case GameState.PlayerTurn:
                StartCoroutine("PlayerTurn");
                break;

            case GameState.EnemyBegin:
                SetCurrentState(GameState.EnemyTurn);
                break;

            case GameState.EnemyTurn:
                StartCoroutine("EnemyTurn");
                break;

            case GameState.TurnEnd:
                SetCurrentState(GameState.KeyInput);
                break;
        }
    }
    //キー入力後プレイヤーの移動中の処理
    IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(TurnDelay);
        SetCurrentState(GameState.EnemyBegin);

    }

    //エネミーターンの処理
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(TurnDelay);
        //GameObject[] EnemyObj = GameObject.FindGameObjectsWithTag("Enemy");

        //EnemyObjの数だけEnemyにアタッチしている移動処理を実行
        //for (int x = 0; x < EnemyObj.Length; ++x)
        //{
        //    yield return new WaitForSeconds(TurnDelay);
        //    EnemyObj[x].GetComponent<Enemy>().MoveEnemy();
        //}
        turn--;
        SetCurrentState(GameState.TurnEnd);
    }


}
