using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "";
    [SerializeField ]private string PlayScene = "Tilemap";

    public void Play() { 
        SceneManager.LoadScene(PlayScene); 
    }

    public void Quit() {
        Application.Quit();
    }

    public void LoadScene() {
        SceneManager.LoadScene(sceneToLoad);
    }
}
