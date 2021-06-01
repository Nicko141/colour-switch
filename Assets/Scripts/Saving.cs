using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saving : MonoBehaviour
{
    public static Player chameleon;

    private void Awake()
    {
        chameleon = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (!PlayerPrefs.HasKey("Loaded"))
        {
            PlayerPrefs.DeleteAll();
            //first load function... set up character data
            FirstLoad();
            //save data... makes first save file in binary
            Save();
            //now have 1st save file
            PlayerPrefs.SetInt("Loaded", 0);

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
    public static void Save()
    {
        //do when binary is done
        Binary.SaveData(chameleon);
    }
    public static void Load()
    {
        //do when binary is done
        Data data = Binary.LoadData(chameleon);
        chameleon.highestY = data.highY;


    }
}
