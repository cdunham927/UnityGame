using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 inp;
    PlayerManager player;
    Quaternion desRot;

    private void Awake()
    {
        player = GetComponent<PlayerManager>();
        Camera.main.GetComponent<CameraController>().SetTarget(transform);
    }

    private void FixedUpdate()
    {
        inp = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (inp.x > 0 && (inp.y < 0.15f && inp.y > -0.15f))
        {
            desRot = Quaternion.Euler(0, 0, -90);
        }
        if (inp.x > 0.15f && inp.y > 0.15f)
        {
            desRot = Quaternion.Euler(0, 0, -45);
        }
        if ((inp.x < 0.15f && inp.x > -0.15f) && inp.y > 0)
        {
            desRot = Quaternion.Euler(0, 0, 0);
        }
        if (inp.x < 0 && inp.y > 0)
        {
            desRot = Quaternion.Euler(0, 0, 45);
        }
        if (inp.x < 0 && (inp.y < 0.15f && inp.y > -0.15f))
        {
            desRot = Quaternion.Euler(0, 0, 90);
        }
        if (inp.x < 0 && inp.y < 0)
        {
            desRot = Quaternion.Euler(0, 0, 135);
        }
        if ((inp.x < 0.15f && inp.x > -0.15f) && inp.y < 0)
        {
            desRot = Quaternion.Euler(0, 0, 180);
        }
        if (inp.x > 0 && inp.y < 0)
        {
            desRot = Quaternion.Euler(0, 0, 225);
        }

        transform.localRotation = desRot;
        player.transform.rotation = desRot;

        SendInputToServer();
    }

    private void SendInputToServer()
    {
        bool[] _inputs = new bool[]
        {
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.A),
            Input.GetKey(KeyCode.D),
        };

        ClientSend.PlayerMovement(_inputs);
    }
}