using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using  TMPro;

#if UNITY_EDITOR
    using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class UIManager : MonoBehaviour
{

    public TMP_InputField nameInput;

    private void Start()
    {
        nameInput = GameObject.Find("NameInput").GetComponent<TMP_InputField>();
    }

    public void StartGame()
    {
        ScoreManager.Instance.Username = nameInput.text;  // get the username
        SceneManager.LoadScene(1);  // main scene
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

}
