using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI highScoreText;
    public static GameManager Instance;

    public string nameInput;

    public int highScore;

    public string playerName;

    [System.Serializable]
    class SaveData {
        public int highScore;
        public string playerName;
    }

    public void SaveScore() {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.playerName = nameInput;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            playerName = data.playerName;
        }
    }

    void Awake() {

        LoadScore();
        highScoreText.text = $"High Score: {highScore} by {playerName}";

        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);


    }

    public void LoadGame() {
        SceneManager.LoadScene(1);
    }


    public void InputName(string name) {
        nameInput = name;
        Debug.Log(nameInput);
    }


    public void ExitGame() {



#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();

#endif
    }
}
