using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RotationEnemyScript : MonoBehaviour
{
    [SerializeField]
    Sprite LaserEnemy;
    [SerializeField]
    Sprite MissileEnemy;

    public LaserScript LaserPrefab;
    public MissileScript MissilePrefab;

    Rigidbody2D rb;
    public GameObject player;

    SpriteRenderer MainSpriteRenderer;
    public string EnemyName;
    public string Direction;
    public bool IsMovePlayer;
    //public int CountLaser;

    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.Find("Player");
        IsMovePlayer = false;
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        
        

        if (EnemyName == "Laser")
        {
            MainSpriteRenderer.sprite = LaserEnemy;
        }
        if (EnemyName == "Missile")
        {
            MainSpriteRenderer.sprite = MissileEnemy;
        }
    }

    // Update is called once per frame
    public void MoveEnemy()
    {

        player = GameObject.Find("Player(Clone)");
        if (Direction == "Right")
            {
                Direction = "Down";
            }
            else if (Direction == "Down")
            {
                Direction = "Left";
            }
            else if (Direction == "Left")
            {
                Direction = "Up";
            }
            else if (Direction == "Up")
            {
                Direction = "Right";
            }
            ChangeSprite();

            switch (Direction)
            {
                case "Right":
                    if (rb.transform.position.x < player.transform.position.x &&
                        rb.transform.position.y == player.transform.position.y)
                    {
                        if (EnemyName == "Laser")
                        {
                                var obj = Instantiate(LaserPrefab, transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
                                obj.transform.right = transform.right;
                        }
                        if (EnemyName == "Missile")
                        {

                            var obj = Instantiate(MissilePrefab, transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
                            obj.transform.right = transform.right;
                        }
                    }
                    break;
                case "Down":
                    if (rb.transform.position.x == player.transform.position.x &&
                        rb.transform.position.y > player.transform.position.y)
                    {
                        if (EnemyName == "Laser")
                        {       
                                var obj = Instantiate(LaserPrefab, transform.position + new Vector3(0.0f, -1.0f, 0.0f), Quaternion.identity);
                                obj.transform.right = transform.right;
                        }
                        if (EnemyName == "Missile")
                        {
                            var obj = Instantiate(MissilePrefab, transform.position + new Vector3(0.0f, -1.0f, 0.0f), Quaternion.identity);
                            obj.transform.right = transform.right;
                        }
                    }
                    break;
                case "Left":
                    if (rb.transform.position.x > player.transform.position.x &&
                        rb.transform.position.y == player.transform.position.y)
                    {
                        if (EnemyName == "Laser")
                        {
                                var obj = Instantiate(LaserPrefab, transform.position + new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
                                obj.transform.right = transform.right;
                        }
                        if (EnemyName == "Missile")
                        {

                            var obj = Instantiate(MissilePrefab, transform.position + new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
                            obj.transform.right = transform.right;
                        }
                    }
                    break;
                case "Up":
                    if (rb.transform.position.x == player.transform.position.x &&
                        rb.transform.position.y < player.transform.position.y)
                    {
                        if (EnemyName == "Laser")
                        {
                                var obj = Instantiate(LaserPrefab, transform.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
                                obj.transform.right = transform.right;
                        }
                        if (EnemyName == "Missile")
                        {
                            var obj = Instantiate(MissilePrefab, transform.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
                            obj.transform.right = transform.right;
                        }
                    }
                    break;
            }
        
    }

    void ChangeSprite()
    {
        Quaternion q = transform.rotation;
        if (Direction == "Right")
        {
            //mainSpriteRender.sprite = defZombie_r;
            q = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Direction == "Down")
        {
            //mainSpriteRender.sprite = defZombie_l;
            q = Quaternion.Euler(0f, 0f, 270f);
        }
        if (Direction == "Left")
        {
            //mainSpriteRender.sprite = defZombie_r;
            q = Quaternion.Euler(0f, 0f, 180f);
        }
        if (Direction == "Up")
        {
            //mainSpriteRender.sprite = defZombie_r;
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
