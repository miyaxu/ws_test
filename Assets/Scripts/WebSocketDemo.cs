using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Use plugin namespace
using HybridWebSocket;
using Newtonsoft.Json;

public class WebSocketDemo : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // Create WebSocket instance
        WebSocket ws = WebSocketFactory.CreateInstance("wss://javascript.info/article/websocket/demo/hello");

        // Add OnOpen event listener
        ws.OnOpen += () =>
        {
            Debug.Log("WS connected!");
            Debug.Log("WS state: " + ws.GetState().ToString());

            ws.Send(Encoding.UTF8.GetBytes("Hello from Unity 3D!"));

            // 以下都不行
            // ws.Send("Hello from Unity 3D!"); // 編譯失敗
            // ws.Send(Encoding.UTF8.GetBytes("{ \"name\": \"searitem\" }")); // 變成帶有byte的字串
            //ws.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new { x = 5, y = 6 }))); // 一樣

        };

        // Add OnMessage event listener
        ws.OnMessage += (byte[] msg) =>
        {
            Debug.Log("WS received message: " + Encoding.UTF8.GetString(msg));

            // ws.Close();
        };

        // Add OnError event listener
        ws.OnError += (string errMsg) =>
        {
            Debug.Log("WS error: " + errMsg);
        };

        // Add OnClose event listener
        ws.OnClose += (WebSocketCloseCode code) =>
        {
            Debug.Log("WS closed with code: " + code.ToString());
        };

        // Connect to the server
        ws.Connect();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
