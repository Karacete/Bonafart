using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogScript : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> textPanel;
    [SerializeField]
    private GameObject gecButton;
    private GameObject loadScript;
    void Start()
    {
        StartCoroutine(Dialog());
        loadScript = GameObject.FindWithTag("Load");
    }
    private IEnumerator Dialog()
    {
        int index = 0;
        foreach (GameObject text in textPanel)
        {
            index += 1;
            text.SetActive(true);
            yield return new WaitForSeconds(3);
            if (index != textPanel.Count)
                text.SetActive(false);
        }
        gecButton.SetActive(true); 
    }
    public void NextScene()
    {
        loadScript.GetComponent<LoadSceneManagerScript>().Load(SceneManager.GetActiveScene().buildIndex + 1);
        SaveData.scene = SceneManager.GetActiveScene().buildIndex + 1;
        SaveLoadScript.Save();
    }
    public void AnaMenu()
    {
        SceneManager.LoadScene(0);
    }
}
