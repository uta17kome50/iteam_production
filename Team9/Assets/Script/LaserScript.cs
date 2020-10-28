using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField, Header("速度"), Range(0, 100)]
    float laserSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //右方向に移動
        transform.position += transform.right * laserSpeed * Time.deltaTime;
        /*
        var velocity = rb.velocity;
        velocity = Vector3.zero;
        if (Direction == "Right")
        {
            //rb.transform.position += new Vector3(10.0f, 0.0f, 0.0f);
            velocity.x = Speed;
        }
        if (Direction == "Down")
        {
            //rb.transform.position += new Vector3(0.0f, -10.0f, 0.0f);
            velocity.y = -Speed; 
        }
        if (Direction == "Left")
        {
            //rb.transform.position += new Vector3(-10.0f, 0.0f, 0.0f);
            velocity.x = -Speed;
        }
        if (Direction == "Top")
        {
            //rb.transform.position += new Vector3(0.0f, 10.0f, 0.0f);
            velocity.y = Speed;
        }
        rb.velocity = velocity;
        */
    }

    /*
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
    */

    void OnCollisionEnter2D(Collision2D other)
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
}
