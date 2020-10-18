using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField]
    GameObject Enemy;
    GameObject gameObj;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        gameObj = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = rb.velocity;
        velocity = Vector2.zero;

        velocity += new Vector2(1.0f,1.0f) * 64;
        rb.velocity = velocity;
    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Stage")|| other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    
}
