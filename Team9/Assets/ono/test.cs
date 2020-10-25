using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public Vector2 speed = new Vector2(0.1f, 0.1f);

    // ターゲットとなるオブジェクト
    private GameObject targetObject;

    // ラジアン変数
    private float rad;

    // 現在位置を代入する為の変数
    private Vector2 Position;

    public Vector3 pos;
    // サーチ用
    bool isSarch;

    // サイン・コサインカーブ
    float angle = 0;
    public float range = 1f;//幅
    float yspeed = 0.04f;//はやさ

    // EnemyDeathスクリプト
    // public EnemyDeath death;

    public float Speed;

    //プレイヤーの追尾開始
    public ParticleSystem core;
    // public TrailRenderer tail;
    public bool particleFlag;

    private GameObject player;

    //public GameObject enemyDeadEffect;

    public ParticleSystem PlayerStartParticle;

    //private PlayerManager playerManager;


    // Use this for initialization
    void Start()
    {

        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        isSarch = true;


        particleFlag = false;
      

        targetObject = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        

        // サーチ範囲に入っているか
        if (isSarch == true)
        {
            this.transform.position = Vector2.MoveTowards
                (this.transform.position, new Vector2
                (targetObject.transform.position.x, targetObject.transform.position.y),
                Speed * Time.deltaTime);

            //if(playerManager.DeadCheck == false)
            //{
            //    isSarch = false;
            //}

           
        }

        // プレイヤーと当たったら死亡(仮)
        //if (death.IsDeath())
        //{ Destroy(gameObject); }
        // 回転
        transform.Rotate(new Vector3(pos.x, pos.y, pos.z) * Time.deltaTime);


    }

    
}
