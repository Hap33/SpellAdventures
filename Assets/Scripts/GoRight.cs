using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoRight : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right*Time.deltaTime*10);
	}
}
