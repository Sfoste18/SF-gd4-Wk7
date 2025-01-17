using UnityEngine;
using System.IO;
using System;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public float timeElapsed;
    public Color unitColor;

    private void Awake()
    {
        //Making sure there is always only one of this (destroy copies)
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        //Setting current object as instance 
        Instance = this;

        //Making object persistent
        DontDestroyOnLoad(gameObject);

        loadColor();
    }

    public void Update()
    {
        //timeElapsed += Time.deltaTime;
    }

    [System.Serializable]
    class saveData
    {
        public Color _unitColor;
    
    }

    public void saveColor()
    {
        saveData data = new saveData();
        data._unitColor = unitColor;

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);

    
    }

    public void loadColor() 
    {
        string jsonData = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
        saveData data = JsonUtility.FromJson<saveData>(jsonData);

        unitColor = data._unitColor;
    
    }
}
