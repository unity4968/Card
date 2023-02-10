
using Newtonsoft.Json.Linq;
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

    [ShowInInspector] public Dictionary<string, string> playerpos;
    [ShowInInspector] public Dictionary<string, string> data;
    [ShowInInspector] public Dictionary<string, string> paydata;
    void Start()
    {
        socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();
        socket.On("Conne", OnConnected);
        socket.On("GetmyPos", GetPOS);
        socket.On("token", gettoken);

        socket.On("disconn", DisConnectuser);
        // data["email"] = "some@email.com";
        // data["pass"] = "1234";
        // Debug.Log("Start");
        // socket.Emit("messages", new JSONObject(data));

        //StartCoroutine(WaitAftersend());
    }

    private void gettoken(SocketIOEvent obj)
    {
        paydata = new Dictionary<string, string>();
        paydata = obj.data.ToDictionary();
        Debug.Log(":save into unity:" + obj.data);

    }

    private void GetPOS(SocketIOEvent obj)
    {
        Debug.Log("" + obj.data);
        playerpos = obj.data.ToDictionary();
    }
    private void DisConnectuser(SocketIOEvent obj)
    {
        Debug.Log("UserDisconnected");
    }
    IEnumerator WaitAftersend()
    {
        yield return null;

        yield return new WaitForSeconds(1f);

        //PlayerJSON playerJSON = new PlayerJSON("demoname");
        //string data = JsonUtility.ToJson(playerJSON);

        data = new Dictionary<string, string>();
        data["UserName"] = UIManager.instance.m_Input.text;
        socket.Emit("StartCheck", new JSONObject(data));
        //socket.Emit("StartCheck", m_json);
    }
    void OnConnected(SocketIOEvent e)
    {
        Debug.Log(" A User Connected:" + e.data);
        var abc = new Dictionary<string, string>();

        abc = e.data.ToDictionary();

        UIManager.instance.OnConnectSuccess(true, abc["UserName"]);

        //Instantiate(playerPrefab, transform.position, Quaternion.identity);
        abc.Clear();
    }
    [Button]
    public void StartGame()
    {
        StartCoroutine(WaitAftersend());
    }

    public void OnpaybtnClick()
    {

        StartCoroutine(waitpay());
    }

    IEnumerator waitpay()
    {
        yield return null;

        yield return new WaitForSeconds(1f);

        socket.Emit("Onpay",new JSONObject(paydata));

    }
}

[System.Serializable]
public class PlayerJSON
{
    public string name;
    public PlayerJSON(string _name)
    {
        name = _name;
    }
    // Given JSON input:
    // {"name":"Dr Charles","lives":3,"health":0.8}
    // this example will return a PlayerInfo object with
    // name == "Dr Charles", lives == 3, and health == 0.8f.
}
