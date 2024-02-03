using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class SaveData
{
    public static int scene;
    public static int language;
}
public class SaveLoadScript
{
    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        using(FileStream fs=new FileStream("gamesave.bin",FileMode.Create,FileAccess.Write))
        {
            bf.Serialize(fs, SaveData.scene);
            bf.Serialize(fs, SaveData.language);
        }
    }
    public static void Load()
    {
        if (!File.Exists("gamesave.bin"))
            return;
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs=new FileStream("gamesave.bin", FileMode.Open,FileAccess.Read))
        {
            SaveData.scene=Convert.ToInt32(bf.Deserialize(fs));
            SaveData.language = Convert.ToInt32(bf.Deserialize(fs));
        }
    }
}
