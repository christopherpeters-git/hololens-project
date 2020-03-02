using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveLoad
{
    private static List<GameObject> _savedGames;
    
    public static void Save()
    {
        _savedGames.Add(PlayerBehaviour.playerObject);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.save");
        bf.Serialize(file,_savedGames);
        file.Close();
    }

    public static void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/savedGames.save")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.save", FileMode.Open);
            _savedGames = (List<GameObject>)bf.Deserialize(file);
            file.Close();
        }
    }
}
