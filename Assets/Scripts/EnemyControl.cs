using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    public float Speed, Life;
    public int Weakness, GreatWeakness;
    public GameObject DeathVFX;

    private bool WentToTheScreen;

    private void Start()
    {
        WentToTheScreen = false;
    }

    private void FixedUpdate()
    {
        if (WentToTheScreen == true)
        {
            transform.Translate(Vector2.left * Time.deltaTime * Speed);
        }

        if (Life == 0)
        {
            Instantiate(DeathVFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnBecameVisible()
    {
        WentToTheScreen = true;
    }

    private void OnBecameInvisible()
    {
        if (WentToTheScreen)
        {
            Instantiate(DeathVFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spell"))
        {
            if (collision.gameObject.GetComponent<SpellActionBomb>() != null)
            {
                SpellActionBomb SpellProjectile = collision.gameObject.GetComponent<SpellActionBomb>();
                if (SpellProjectile.SpellType == Weakness)
                {
                    Life--;
                }
                if (SpellProjectile.SpellType == GreatWeakness)
                {
                    Life=0;
                }
            }
            else
            {
                SpellAction SpellProjectile = collision.gameObject.GetComponent<SpellAction>();
                if (SpellProjectile.SpellType == Weakness)
                {
                    Life--;
                }
                if (SpellProjectile.SpellType == GreatWeakness)
                {
                    Life = 0;
                }
            }
        }
    }
}
