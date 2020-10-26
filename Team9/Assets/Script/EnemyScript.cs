using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    Sprite LezarEnemy;
    [SerializeField]
    Sprite MissileEnemy;

    Rigidbody2D rb;

    public GameObject LezarObj;
    public GameObject MissileObj;

    public GameObject Player;

    SpriteRenderer MainSpriteRenderer;
    public string EnemyName;
    public string Direction;
    public bool IsMovePlayer;
    public int CountLaser;

    // Start is called before the first frame update
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        IsMovePlayer = false;
        if (EnemyName == "Laser")
        {
            MainSpriteRenderer.sprite = LezarEnemy;
        }
        if (EnemyName == "Missile")
        {
            MainSpriteRenderer.sprite = MissileEnemy;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Player.transform.position);
        Debug.Log(rb.transform.position);
        ChangeSprite();
        if (IsMovePlayer == true)
        {
            switch (Direction)
            {
                case "Right":
                    if (rb.transform.position.x < Player.transform.position.x &&
                        rb.transform.position.y == Player.transform.position.y)
                    {
                        if (EnemyName == "Laser")
                        {
                            Instantiate(LezarObj, transform.position + new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);
                        }
                        if (EnemyName == "Missile")
                        {
                            if (CountLaser == 3)
                            {
                                Instantiate(MissileObj, transform.position + new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);
                                CountLaser = 0;
                            }
                            CountLaser++;
                        }
                    }
                    break;
                case "Down":
                    if (rb.transform.position.x == Player.transform.position.x &&
                        rb.transform.position.y > Player.transform.position.y)
                    {
                        if (EnemyName == "Laser")
                        {
                            Instantiate(LezarObj, transform.position + new Vector3(0.0f, -2.0f, 0.0f), Quaternion.identity);
                        }
                        if (EnemyName == "Missile")
                        {
                            if (CountLaser == 3)
                            {
                                Instantiate(MissileObj, transform.position + new Vector3(0.0f, -2.0f, 0.0f), Quaternion.identity);
                                CountLaser = 0;
                            }
                            CountLaser++;
                        }
                    }
                    break;
                case "Left":
                    if (rb.transform.position.x > Player.transform.position.x &&
                        rb.transform.position.y == Player.transform.position.y)
                    {
                        if (EnemyName == "Laser")
                        {
                            Instantiate(LezarObj, transform.position + new Vector3(-2.0f, 0.0f, 0.0f), Quaternion.identity);
                        }
                        if (EnemyName == "Missile")
                        {
                            if (CountLaser == 3)
                            {
                                Instantiate(MissileObj, transform.position + new Vector3(-2.0f, 0.0f, 0.0f), Quaternion.identity);
                                CountLaser = 0;
                            }
                            CountLaser++;
                        }
                    }
                    break;
                case "Top":
                    if (rb.transform.position.x == Player.transform.position.x &&
                        rb.transform.position.y < Player.transform.position.y)
                    {
                        if (EnemyName == "Laser")
                        {
                            Instantiate(LezarObj, transform.position + new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);
                        }
                        if (EnemyName == "Missile")
                        {
                            if (CountLaser == 3)
                            {
                                Instantiate(MissileObj, transform.position + new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);
                                CountLaser = 0;
                            }
                            CountLaser++;
                        }
                    }
                    break;
            }
            IsMovePlayer = false;
        }
    }

    void ChangeSprite()
    {
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
        if (Direction == "Top")
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

    void OnCollision2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            Destroy(gameObject);
        }
    }
}
