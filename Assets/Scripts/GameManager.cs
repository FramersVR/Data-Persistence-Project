using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public string nameInput;

    public int highScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Display high score on the HighScore TextMeshPro Text
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
