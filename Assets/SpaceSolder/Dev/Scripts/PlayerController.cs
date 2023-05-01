using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData playerData;

    public void Init(PlayerData data)
    {
        playerData = data;
        
        transform.position = playerData.PlayerPosition;
        transform.rotation = playerData.PlayerRotation;
    }
}
