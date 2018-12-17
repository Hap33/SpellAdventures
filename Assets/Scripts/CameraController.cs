using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Transform Player;
    private float XOffset;

    public float CamSpeedToPlayer, YOffset;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        XOffset = GetComponent<Camera>().orthographicSize;
    }

    private void Update()
    {
        Vector2 camPos = new Vector2(Player.position.x + XOffset, Player.position.y+YOffset);
        transform.position = Vector2.MoveTowards(transform.position, camPos, CamSpeedToPlayer*Time.deltaTime);
    }
}
