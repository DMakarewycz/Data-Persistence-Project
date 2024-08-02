using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuUIHandler : MonoBehaviour
{

    public string username;
    public TMP_InputField inputField;
    

    public void NameSelected() {
        string newName = inputField.GetComponent<TMP_InputField>().text;
        if (newName.Length > 0) {
            MenuManager.Instance.currName = inputField.text;
        }
        else {
            Debug.Log("Please input a name first!");
        }
    }

    public void StartNew() {
        if (MenuManager.Instance.currName != null && MenuManager.Instance.currName.Length > 0) {
            SceneManager.LoadScene(1);
        }
    }

    public void Exit() {
        #if Unity_Editor
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
