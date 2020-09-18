using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public float currentLibrary;
    // Start is called before the first frame update
    void Start()
    {
        SaveManager.instance = this;
    }
    public void Save(float saveLibrary)
    {
        currentLibrary = saveLibrary;
        if (saveLibrary >= PlayerPrefs.GetFloat("MaxLibrary"))
            PlayerPrefs.SetFloat("MaxLibrary", saveLibrary);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
