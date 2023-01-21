using UnityEngine;
using System.IO;

public class JsonFileSystem : MonoBehaviour
{
    #region Singleton
    public static JsonFileSystem instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    #endregion

    public void SaveToJson()
    {
        string auxPath = Application.dataPath + "/SaveFile.json";
        if (FileExists(auxPath))
        {
            DeleteSaveFile(auxPath);
        }

        SaveData svData = new SaveData();
        svData.sv_maxScore = ScoreManager.instance.s_maxScore;

        string json = JsonUtility.ToJson(svData, true);
        File.WriteAllText(Application.dataPath + "/SaveFile.json", json);
        Debug.Log("New save file at: " + auxPath);
    }

    public void LoadSaveFile()
    {
        //string jsonPath = File.ReadAllText(Application.dataPath + "/SaveFile.json"); BORRAR
        string jsonPath = Application.dataPath + "/SaveFile.json";
        if (FileExists(jsonPath))
        {
            jsonPath = File.ReadAllText(Application.dataPath + "/SaveFile.json");
            SaveData svData = JsonUtility.FromJson<SaveData>(jsonPath);
            ScoreManager.instance.s_maxScore = svData.sv_maxScore;
        }
        else
        {
            Debug.Log("No save file found, start from 0!");
        }
    }

    public void DeleteSaveFile(string _json)
    {
        //_json = File.ReadAllText(Application.dataPath + "/SaveFile.json");
        File.Delete(_json);
        Debug.Log("Save file deleted");
    }
    public void DeletePossibleSaveFile()
    {
        string auxPath = Application.dataPath + "/SaveFile.json";
        if (FileExists(auxPath))
        {
            DeleteSaveFile(auxPath);
        }
        else
        {
            Debug.Log("There is no save file to be deleted");
        }
    }

    private bool FileExists(string _json)
    {
        if (File.Exists(_json)) { return true; }
        else { return false; }
    }
}
