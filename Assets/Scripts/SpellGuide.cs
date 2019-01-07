using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellGuide : MonoBehaviour {

    #region Singleton
    public static SpellGuide Singleton;

    private void Awake()
    {
        if(Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Singleton = this;
        }
    }
    #endregion

    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).z+10);
        }
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.parent.GetComponent<SpellControl>() != null)
        {
            collision.transform.parent.GetComponent<SpellControl>().CheckChild(collision.transform.GetSiblingIndex());
        }
    }
}
