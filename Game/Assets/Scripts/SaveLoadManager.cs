using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
   /* string filePath;
    public List<GameObject> EnemySaves =
        new List<GameObject>();
    private void Start()
    {
        filePath = Application.persistentDataPath + "/save.gamesave/", FileMode.Create;

    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);
        Save save = new Save();
        save.saveEnemies(EnemySaves);
        bf.Serialize(fs, save);
        fs.Close();
        
    }
    public void LoadGame()
    {
        if (File.Exists(filePath))
            return;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);
        Save save = (Save)bf.Deserialize(fs);
        fs.Close();

        int i = 0;
        foreach (var enemy in save.EnemiesData)
        {
            EnemySaves[i].GetComponent<EnemyPatrool>().LoadData(enemy);
            i++;
        }
    }
    
   
}
[System.Serializable]
public class Save
{
    public struct Vector3
    {
        public float x, y, z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
       

        
    }
    [System.Serializable]
    public struct EnemySaveData
    {

        public Vector3 Position;
        public EnemySaveData(Vector3 pos, Vector3 dir)
        {
            Position = pos;
           
        }




    }
    public List<EnemySaveData> EnemiesData =
        new List<EnemySaveData>();
    public void saveEnemies(List<GameObject> enemies)
    {
        foreach(var go in enemies)
        {
            var em = go.GetComponent<EnemyPatrool>();

            Vector3 pos = new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z);
            EnemiesData.Add(new EnemySaveData*/


           


 }
    




 
