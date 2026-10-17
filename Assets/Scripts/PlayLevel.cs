using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VectorGraphics;
using UnityEngine.SceneManagement;
using Unity.Tutorials.Editor;
using System.ComponentModel.Design.Serialization;

public class PlayLevel : MonoBehaviour
{
    public Button playLevelButton;
    public string sceneName;
    void Start()
    {
        playLevelButton.GetComponent<Button>().onClick.AddListener(play1Level);    
    }

    private void play1Level() {

        SceneManager.LoadScene(sceneName);
    }
}
