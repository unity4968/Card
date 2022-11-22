using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkMove : MonoBehaviour
{
    public SocketIOComponent socket;
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            OnMoveRight();
        }
    }
    public void OnMoveRight()
    {
        Debug.Log("sending position to node: ");
        socket.Emit("move right");
    }
}
