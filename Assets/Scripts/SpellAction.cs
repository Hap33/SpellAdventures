using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAction : MonoBehaviour {

    private GameObject Player;

    public int SpellType;
    public float SpellSpeed;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * Time.deltaTime * SpellSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            Debug.Log("IzGood");
            //TODO Collision with monster
            Destroy(gameObject);
        }
    }
}
