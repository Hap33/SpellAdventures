using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActionBomb : MonoBehaviour {

    private GameObject Player;

    public int SpellType;
    public float SpellSpeed;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * SpellSpeed);
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * SpellSpeed*3);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            //TODO Collision with monster
            Destroy(gameObject);
        }
    }
}
