using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    EnemyScript enemyScript;
    Rigidbody2D rb;

    string Direction;
    string Type;

    bool IsMovePlayer;

    // Start is called before the first frame update
    void Start()
    {
        enemyScript = enemy.GetComponent<EnemyScript>();
        Direction = enemyScript.RetrunDirection();
        Type = "Missile";
        IsMovePlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMovePlayer == true)
        {
            if (Direction == "Right")
            {
                rb.transform.position = new Vector3(1.0f, 0.0f, 0.0f);
            }
            if (Direction == "Down")
            {
                rb.transform.position = new Vector3(0.0f, -1.0f, 0.0f);
            }
            if (Direction == "Left")
            {
                rb.transform.position = new Vector3(-1.0f, 0.0f, 0.0f);
            }
            if (Direction == "Top")
            {
                rb.transform.position = new Vector3(0.0f, 1.0f, 0.0f);
            }
        }
        IsMovePlayer = false;
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

    void OnCollision2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Stage"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public string ReturnData()
    {
        return Direction;
    }

    public string RetrunType()
    {
        return Type;
    }
}
