using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.position.y > this.transform.position.y)//follow the player's y axis
        {
            this.transform.position = new Vector3(this.transform.position.x,player.position.y, this.transform.position.z);
        }
        
    }
}
