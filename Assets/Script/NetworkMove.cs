using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkMove : MonoBehaviour
{
    public SocketIOComponent socket;
    float speed = 10;
    private void Start()
    {
        socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();
    }
    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;
        if (transform.position!=Vector3.zero)
        {
            ChangePos();
        }

    }
    public void ChangePos()
    {
        Debug.Log("sending position to node: ");
        var pos = new Dictionary<string, string>();
        pos["position"] = transform.position.ToString();
        pos["rotation"] = transform.rotation.ToString();

        socket.Emit("position", new JSONObject(pos));
    }
}
