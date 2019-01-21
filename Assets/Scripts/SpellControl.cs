using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellControl : MonoBehaviour {

    public int SpellNumber;

    private int CornerCount;
    private GameObject[] OtherSpell;

    private void Start()
    {
        CornerCount = 0;
        OtherSpell = GameObject.FindGameObjectsWithTag("Spell");
    }

    private void Update()
    {
        if (CornerCount == transform.childCount)
        {
            FindObjectOfType<PlayerController>().SpellThrow(SpellNumber-1);
            CornerCount = 0;
        }
        transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z+10);

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            CornerCount = 0;
        }

        if(CornerCount > 1)
        {
            foreach (GameObject spell in OtherSpell)
            {
                if (spell != gameObject)
                {
                    spell.SetActive(false);
                }
            }
        }else if(CornerCount == 0)
        {
            foreach (GameObject spell in OtherSpell)
            {
                if (spell != gameObject)
                {
                    spell.SetActive(true);
                }
            }
        }
    }

    public void CheckChild(int childCount)
    {
        if (childCount == CornerCount)
        {
            CornerCount++;
        }
        else if (childCount != CornerCount)
        {
            CornerCount = 0;
        }
    }
}
