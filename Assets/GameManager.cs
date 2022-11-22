
using Sirenix.OdinInspector;
using SocketIO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static SocketIOComponent socket;
    public GameObject playerPrefab;

    // Use this for initialization
    Dictionary<string, string> data;
    void Start()
    {
        socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();

        socket.On("ABC", testmethod);
        socket.On("vv", OnConnected);

        data = new Dictionary<string, string>();
        data["email"] = "some@email.com";
        data["pass"] = "1234";

        Debug.Log("Start");
        socket.Emit("messages", new JSONObject(data));

        StartCoroutine(WaitAftersend());
    }
    IEnumerator WaitAftersend()
    {
        yield return null;

           yield return new WaitForSeconds(1f);
        socket.Emit("first");
    }
    private void testmethod(SocketIOEvent obj)
    {
        Debug.Log("Its test method call from Node" + obj.data);
    }
    [Button]
    public void sendMessage()
    {
        socket.Emit("first");
        // socket.Emit("vv");
    }
    void OnConnected(SocketIOEvent e)
    {
        Debug.Log("OnConnected:" + e.data);
    }
    void OnSpawned(SocketIOEvent e)
    {
        Debug.Log("spawned object");
        Instantiate(playerPrefab);
    }
    void OnMoveRight(SocketIOEvent e)
    {
    }
}
