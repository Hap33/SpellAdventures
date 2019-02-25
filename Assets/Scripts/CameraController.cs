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
        if (Player != null)
        {
            Vector3 camPos = new Vector3(Player.position.x + XOffset, Player.position.y + YOffset, Player.position.z - 12);
            transform.position = Vector3.MoveTowards(transform.position, camPos, CamSpeedToPlayer * Time.deltaTime);
        }
    }
}
