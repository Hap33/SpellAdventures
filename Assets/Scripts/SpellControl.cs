using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellControl : MonoBehaviour {

    public int SpellNumber;

    private int CornerCount;

    private void Start()
    {
        CornerCount = 0;
    }

    private void Update()
    {
        if (CornerCount == transform.childCount)
        {
            FindObjectOfType<PlayerController>().SpellThrow(SpellNumber-1);
            CornerCount = 0;
        }
        transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z+10);
    }

    public void CheckChild(int childCount)
    {
        if (childCount == CornerCount)
        {
            CornerCount++;
        }
        else if (childCount > CornerCount)
        {
            CornerCount = 0;
        }
    }
}
