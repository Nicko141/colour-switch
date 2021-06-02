using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saving : MonoBehaviour
{
    public static Player chameleon;

    private void Awake()
    {
        chameleon = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();//find player and add the pplayer script if not already attached
        if (chameleon.highestY <= 0)
        {

            FirstLoad();
        }
        else
        {
            Load();
        }
    }
    void FirstLoad()
    {
        chameleon.highestY = 0;

    }
    public static void Save()//save the data
    {
        //do when binary is done
        Binary.SaveData(chameleon);
    }
    public static void Load()//loads the data
    {
        //do when binary is done
        Data data = Binary.LoadData(chameleon);
        chameleon.highestY = data.highY;


    }
}
