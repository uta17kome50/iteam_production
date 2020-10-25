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

    GameObject Player;

    SpriteRenderer MainSpriteRenderer;
    public string EnemyName;
    public string Direction;
    bool IsMovePlayer;

    // Start is called before the first frame update
    void Start()
    {
        IsMovePlayer = false;
        MainSpriteRenderer.sprite = GetComponent<Sprite>();
        if (EnemyName == "Laser")
        {
            MainSpriteRenderer.sprite = LezarEnemy;
        }
        if (EnemyName == "Missile")
        {
            MainSpriteRenderer.sprite = MissileEnemy;
        }
        IsMovePlayer = false;
        MainSpriteRenderer.sprite = GetComponent<Sprite>();
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
        ChangeSprite();
        //IsMovePlayer = 
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
                            Instantiate(LezarObj, transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
                        }
                        if (EnemyName == "Missile")
                        {
                            Instantiate(MissileObj, transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
                        }
                    }
                    break;
                case "Down":
                    if (rb.transform.position.x == Player.transform.position.x &&
                        rb.transform.position.y > Player.transform.position.y)
                    {
                        if (EnemyName == "Laser")
                        {
                            Instantiate(LezarObj, transform.position + new Vector3(0.0f, -1.0f, 0.0f), Quaternion.identity);
                        }
                        if (EnemyName == "Missile")
                        {
                            Instantiate(MissileObj, transform.position + new Vector3(0.0f, -1.0f, 0.0f), Quaternion.identity);
                        }
                    }
                    break;
                case "Left":
                    if (rb.transform.position.x > Player.transform.position.x &&
                        rb.transform.position.y == Player.transform.position.y)
                    {
                        if (EnemyName == "Laser")
                        {
                            Instantiate(LezarObj, transform.position + new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
                        }
                        if (EnemyName == "Missile")
                        {
                            Instantiate(MissileObj, transform.position + new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
                        }
                    }
                    break;
                case "Top":
                    if (rb.transform.position.x == Player.transform.position.x &&
                        rb.transform.position.y < Player.transform.position.y)
                    {
                        if (EnemyName == "Laser")
                        {
                            Instantiate(LezarObj, transform.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
                        }
                        if (EnemyName == "Missile")
                        {
                            Instantiate(MissileObj, transform.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
                        }
                    }
                    break;
            }
        }
    }

    void ChangeSprite()
    {
        if (Direction == "right")
        {
            //mainSpriteRender.sprite = defZombie_r;
            rb.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0.0f, transform.rotation.w);
        }
        if (Direction == "Down")
        {
            //mainSpriteRender.sprite = defZombie_l;
            rb.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 90.0f, transform.rotation.w);
        }
        if (Direction == "Left")
        {
            //mainSpriteRender.sprite = defZombie_r;
            rb.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 180.0f, transform.rotation.w);
        }
        if (Direction == "Top")
        {
            //mainSpriteRender.sprite = defZombie_r;
            rb.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 270.0f, transform.rotation.w);
        }
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
