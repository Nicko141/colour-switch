using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Binary
{
    public static void SaveData(Player chameleon)
    {
        //reference a binary formatter
        BinaryFormatter formatter = new BinaryFormatter();
        //location to save file
        string path = Application.persistentDataPath + "/" + "Trumpet" + ".wav";
        //create file at file path
        FileStream stream = new FileStream(path, FileMode.Create);
        //what data to write to the file
        Data data = new Data(chameleon);
        //write it and convert to bytes for writing to binary
        formatter.Serialize(stream, data);
        //and we're done
        stream.Close();
    }
    public static Data LoadData(Player chameleon)
    {
        //location
        string path = Application.persistentDataPath + "/" + "Trumpet" + ".wav";
        //if we have file at path
        if (File.Exists(path))
        {
            //get binary formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //read the data 
            FileStream stream = new FileStream(path, FileMode.Open);
            //set the data from what it is back to useable data
            Data data = formatter.Deserialize(stream) as Data;
            //we are done
            stream.Close();
            //but wait there's more, send usable data back to playerdatatosave script
            return data;
        }
        else
        {
            return null;
        }

    }
}


   

