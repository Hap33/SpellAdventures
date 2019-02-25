using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

    public float TimeBeforeDeath;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, TimeBeforeDeath);
	}
}
