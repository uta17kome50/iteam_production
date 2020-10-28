using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    Sprite LaserEnemy; //レーザーを撃つ敵の画像
    [SerializeField]
    Sprite MissileEnemy;　//ミサイルを撃つ的の画像

    Rigidbody2D rb;

    public LaserScript LaserPrefab;　//レーザーのプレハブ
    public MissileScript MissilePrefab;　//ミサイルのプレハブ
    
    //GameObject Player;

    SpriteRenderer MainSpriteRenderer; 
    public string EnemyName;
    public string Direction;
    public bool IsMovePlayer;
    public int CountLaser;

    private MissileScript activeMissile;

    // Start is called before the first frame update
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        IsMovePlayer = false;
        //敵の種類を判定
        if (EnemyName == "Laser")
        {
            MainSpriteRenderer.sprite = LaserEnemy;
        }
        if (EnemyName == "Missile")
        {
            MainSpriteRenderer.sprite = MissileEnemy;
        }
        ChangeRotation();
    }

    // Update is called once per frame
    public void MoveEnemy()
    {
        
        //敵の向きによって撃つ方向を変える
            switch (Direction)
            {
                case "Right":
                    if (EnemyName == "Laser")
                    {
                        if (CountLaser == 3)
                        {
                            var obj = Instantiate(LaserPrefab, transform.position + new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                            obj.transform.right = transform.right;
                            CountLaser = 0;
                        }
                        CountLaser++;
                    }
                    if (EnemyName == "Missile")
                    {
                        if (activeMissile != null) break;
                        var obj = Instantiate(MissilePrefab, transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
                        obj.transform.right = transform.right;
                        activeMissile = obj.GetComponent<MissileScript>();
                    }
                    break;
                case "Down":
                    if (EnemyName == "Laser")
                    {
                        if (CountLaser == 3)
                        {
                            var obj = Instantiate(LaserPrefab, transform.position + new Vector3(0.0f, -1.0f, 0.0f), Quaternion.identity);
                            obj.transform.right = transform.right;
                            CountLaser = 0;
                        }
                        CountLaser++;
                    }
                    if (EnemyName == "Missile")
                    {
                        if (activeMissile != null) break;
                        var obj = Instantiate(MissilePrefab, transform.position + new Vector3(0.0f, -1.0f, 0.0f), Quaternion.identity);
                        obj.transform.right = transform.right;
                        activeMissile = obj.GetComponent<MissileScript>();
                    }
                    break;
                case "Left":
                    if (EnemyName == "Laser")
                    {
                        if (CountLaser == 3)
                        {
                            var obj = Instantiate(LaserPrefab, transform.position + new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
                            obj.transform.right = transform.right;
                            CountLaser = 0;
                        }
                        CountLaser++;
                    }
                    if (EnemyName == "Missile")
                    {
                        if (activeMissile != null) break;
                        var obj = Instantiate(MissilePrefab, transform.position + new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
                        obj.transform.right = transform.right;
                        activeMissile = obj.GetComponent<MissileScript>();
                    }
                    break;
                case "Up":
                    if (EnemyName == "Laser")
                    {
                        if (CountLaser == 3)
                        {
                            var obj = Instantiate(LaserPrefab, transform.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
                            obj.transform.right = transform.right;
                            CountLaser = 0;
                        }
                        CountLaser++;
                    }
                    if (EnemyName == "Missile")
                    {
                        if (activeMissile != null) break;
                        var obj = Instantiate(MissilePrefab, transform.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
                        obj.transform.right = transform.right;
                        activeMissile = obj.GetComponent<MissileScript>();
                    }
                    break;
            }
            
    }

    void ChangeRotation()
    {
        //敵の向きによって回転する
        Quaternion q = transform.rotation;
        if (Direction == "Right")
        {
            //mainSpriteRender.sprite = defZombie_r;
            //rb.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0.0f, transform.rotation.w);
            q = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Direction == "Down")
        {
            //mainSpriteRender.sprite = defZombie_l;
            //rb.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 90.0f, transform.rotation.w);
            q = Quaternion.Euler(0f, 0f, 270f);
        }
        if (Direction == "Left")
        {
            //mainSpriteRender.sprite = defZombie_r;
            //rb.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 180.0f, transform.rotation.w);
            q = Quaternion.Euler(0f, 0f, 180f);
        }
        if (Direction == "Up")
        {
            //mainSpriteRender.sprite = defZombie_r;
            //rb.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 270.0f, transform.rotation.w);
            q = Quaternion.Euler(0f, 0f, 90f);
        }
        transform.rotation = q;
    }

    public string RetrunDirection()
    {
        return Direction;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Missile"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Laser"))
        {
            Destroy(gameObject);
        }
    }
}
