using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fusion;

public class MultiplayerChat : NetworkBehaviour
{
    public Text _message;
    public Text input;
    public Text usernameInput;
    public string username = "Default";

    public void SetUsername() 
    {
        username = usernameInput.text;
    }

    public void CallMessageRPC()
    {
        string message = input.text;
        RPC_SendMessage(username, message);
    }

    [Rpc(RpcSources.All, RpcTargets.All)]

    public void RPC_SendMessage(string username, string message, RpcInfo rpcInfo = default)
    {
        _message.text += $"{username}: {message}\n";
    }
}
