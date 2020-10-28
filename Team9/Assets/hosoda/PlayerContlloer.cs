using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;//追加

public class PlayerContlloer : MonoBehaviour
{
    public LaserScript LaserPrefab;
    public MissileScript MissilePrefab;

    //    Vector3 MOVEX = new Vector3(0.64f, 0, 0); // x軸方向に１マス移動するときの距離
    //    Vector3 MOVEY = new Vector3(0, 0.64f, 0); // y軸方向に１マス移動するときの距離
    public GameObject GameManager;
    public GameState PlayerState;
    public float speed = 1f;     // 移動速度
    //Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
    //Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存
    Animator animator;   // アニメーション
    Rigidbody2D rb;
    //Stack<string> StackBalletDitection = new Stack<string>();//弾の方向を格納
    //Stack<string> StackBalletType = new Stack<string>();//弾の種類を格納
    struct Ballet
    {
        public Vector3 Direction;
        public string Type;
        public Ballet (Vector3 dir,string btype)
        {
            Direction = dir;
            Type = btype;
        } 
    }
   List<Ballet>  balletList = new List<Ballet>();
    Image stock1, stock2, stock3;
    private GameObject activeWeapon;


    // Use this for initialization
    void Start()
    {
        //target = transform.position;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //オブジェクトの取得
        stock1 = GameObject.Find("stock1").GetComponent<Image>();
        stock2 = GameObject.Find("stock2").GetComponent<Image>();
        stock3 = GameObject.Find("stock3").GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {

        //// ① 移動中かどうかの判定。移動中でなければ入力を受付
        //if (transform.position == target)
        //{
        //    SetTargetPosition();
        //}
        Move();
        Attack();
        Death();
    }

    // ② 入力に応じて移動後の位置を算出
    //void SetTargetPosition()
    //{

    //    prevPos = target;

    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        target = transform.position + MOVEX;
    //        //SetAnimationParam(1);
    //        return;
    //    }
    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        target = transform.position - MOVEX;
    //        //SetAnimationParam(2);
    //        return;
    //    }
    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        target = transform.position + MOVEY;
    //        //SetAnimationParam(3);
    //        return;
    //    }
    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        target = transform.position - MOVEY;
    //        //SetAnimationParam(0);
    //        return;
    //    }
    //}

    // WalkParam  0;下移動　1;右移動　2:左移動　3:上移動
    //void SetAnimationParam(int param)
    //{
    //    animator.SetInteger("WalkParam", param);
    //}

    // ③ 目的地へ移動する
    void Move()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        PlayerState = GameManager.GetComponent<Gamemanager>().CurrentGameState;
        //Debug.Log(PlayerState);

        if (PlayerState == GameState.KeyInput)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0)
            {
                if (transform.position.x != 6)
                {
                    transform.position += transform.right * 1.0f;
                    GameManager.GetComponent<Gamemanager>().SetCurrentState(GameState.PlayerTurn);
                    //UpdatePlayerPossision(velocity.x, velocity.y);
                }

            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0)
            {
                if (transform.position.x != 1)
                {
                    transform.position += transform.right * -1.0f;
                    GameManager.GetComponent<Gamemanager>().SetCurrentState(GameState.PlayerTurn);
                    //UpdatePlayerPossision(velocity.x, velocity.y);
                }

            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("Vertical") > 0)
            {
                if (transform.position.y != 6)
                {
                    transform.position += transform.up * 1.0f;
                    GameManager.GetComponent<Gamemanager>().SetCurrentState(GameState.PlayerTurn);
                    // UpdatePlayerPossision(velocity.x, velocity.y);
                }

            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Vertical") < 0)
            {
                if (transform.position.y != 1)
                {
                    transform.position += transform.up * -1.0f;
                    GameManager.GetComponent<Gamemanager>().SetCurrentState(GameState.PlayerTurn);
                    // UpdatePlayerPossision(velocity.x, velocity.y);
                }

            }


        }

        // rb.velocity = velocity;
        //transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
    }
    //攻撃
    void Attack()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        PlayerState = GameManager.GetComponent<Gamemanager>().CurrentGameState;
        if (PlayerState == GameState.KeyInput)

            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("joystick button 1"))
        {
            if (balletList.Count <= 0)
            {
                return;
            }
            RemoveStockUI();
            var dir = balletList[0].Direction;
            var type = balletList[0].Type;
            Debug.Log(dir + " >> " + type);
            balletList.RemoveAt(0);
            GameObject prefab = null;
            switch (type)
            {
                case "Laser":
                    prefab = LaserPrefab.gameObject;
                    break;
                case "Missile":
                    prefab = MissilePrefab.gameObject;
                    break;
            }

            var obj = Instantiate(prefab, transform.position + dir * 1.0f, Quaternion.identity);
            obj.transform.right = dir;
            activeWeapon = obj.gameObject;
                GameManager.GetComponent<Gamemanager>().SetCurrentState(GameState.PlayerTurn);

            }
    }
    //死亡
    void Death()
    {
        //キャパオーバーした時
        if (balletList.Count > 3)
        {
            Destroy(this.gameObject);
            FadeManager.FadeOut("End");
        }
    }
    private Vector3 GetDirection(string dir)
    {
        switch (dir)
        {
            case "Right":
                return Vector3.right;
            case "Left":
                return Vector3.left;
            case "Up":
                return Vector3.up;
            case "Down":
                return Vector3.down;
        }
        return Vector3.zero;
    }
    // 衝突時のXY平面の角度計算
    public float GetDeg_XY(Vector3 vector)
    {
        var vec = (new Vector2(vector.x, vector.y)).normalized * 100.0f;
        float rad = Mathf.Atan2(vector.y, vector.x);
        return rad * Mathf.Rad2Deg;
    }
    //方向を検知
    private string Direction(float deg)
    {
        if (45.0f < deg && deg <= 135.0f) return ("Down");
        if (135.0f < deg || deg <= -135.0f) return ("Right");
        if (-135.0f < deg && deg <= -45.0f) return ("Up");
        if (-45.0f < deg && deg <= 45.0f) return ("Left");
        return null;
    }
    //ストックUIの変更
    private void AddStockUI(Sprite sprite)
    {
        if (stock1.color.a <= 0.0f)
        {

            stock1.sprite = sprite;

            var color = stock1.color;
            color.a = 1;
            stock1.color = color;
        }
        else if (stock2.color.a <= 0.0f)
        {
            stock2.sprite = sprite;

            var color = stock2.color;
            color.a = 1;
            stock2.color = color;
        }
        else if (stock3.color.a <= 0.0f)
        {
            stock3.sprite = sprite;

            var color = stock3.color;
            color.a = 1;
            stock3.color = color;
        }
    }
    private void RemoveStockUI()
    {
        Debug.Log("before " + stock1.sprite + "/" + stock2.sprite + "/" + stock3.sprite);
        stock1.sprite = stock2.sprite;
        stock1.color = stock2.color;
        stock2.sprite = stock3.sprite;
        stock2.color = stock3.color;
        stock3.sprite = null;
        stock3.color = new Color(1, 1, 1, 0);
        Debug.Log("after " + stock1.sprite + "/" + stock2.sprite + "/" + stock3.sprite);

    }
    private Sprite GetWeaponSprite(string name, string dir)
    {
        var s = name.ToUpper() + "_" + dir.ToUpper();
        Debug.Log(s);
        return Resources.Load<Sprite>(name.ToUpper() + "_" + dir.ToUpper());

    }

    //弾と衝突時
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy")|| other.gameObject.CompareTag("REnemy"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject == activeWeapon) return;
        Debug.Log("hit");
        switch (other.gameObject.tag)
        {
            case "Missile":
            case "Laser":
                //if (other.gameObject.CompareTag("Missile") || other.gameObject.CompareTag("Laser"))
                //{

                if (other.contacts.Length <= 0) return;//衝突してないならリターン
                var start = other.contacts[0].point;
                var vector = Vector2.zero;
                // すべての衝突位置を調べて、向き（ベクトル）を求める
                for (int i = 0; i < other.contacts.Length - 1; i++)
                {
                    var point_start = (other.contacts[i].point);
                    var point_end = (other.contacts[i + 1].point);
                    vector += (point_end - point_start);
                    Debug.Log(point_start + " / " + point_end);
                }

                // 中点の計算
                vector /= 2.0f;
                Vector3 pos = start + vector;

                // 上記の「中点の計算の下から記入」
                float deg = GetDeg_XY(pos - transform.position);

                var dir = Direction(deg);
                Debug.Log("Direction>> " + dir);
                Debug.Log("Type>>" + other.gameObject.tag);
                balletList.Add(new Ballet(GetDirection(dir),other.gameObject.tag));
                var sprite = GetWeaponSprite(other.gameObject.tag, dir);
                if (sprite != null)
                {
                    AddStockUI(sprite);
                }

                break;

        }
    }

}
