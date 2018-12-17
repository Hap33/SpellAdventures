using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float Speed;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * Speed);
    }
}
