﻿using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Socket.Quobject.SocketIoClientDotNet.Client;
using UnityEngine;

public class TestObject : MonoBehaviour
{
    private QSocket socket;
    private void OnEnable()
    {
        socket = IO.Socket("http://localhost:3000");
    }

    [Button]
    void OnStart()
    {
        Debug.Log("start");
        socket = IO.Socket("http://localhost:3000");
        Debug.Log("start"+ socket);

        socket.On(QSocket.EVENT_CONNECT, () =>
        {
            Debug.Log("Connected");
            socket.Emit("chat", "test");
        });

        socket.On("chat", data =>
        {
            Debug.Log("data : " + data);
        });
    }

    private void OnDestroy()
    {
        socket.Disconnect();
    }
}