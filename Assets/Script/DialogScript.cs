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
    private LoadSceneManagerScript loadScript;
    void Start()
    {
        StartCoroutine(Dialog());
        loadScript = GameObject.FindWithTag("Load").GetComponent<LoadSceneManagerScript>();
    }
    private IEnumerator Dialog()
    {
        int index = 0;
        foreach (GameObject text in textPanel)
        {
            index += 1;
            text.SetActive(true);
            yield return new WaitForSeconds(3);
            gecButton.SetActive(true);
            if (index != textPanel.Count)
                text.SetActive(false);
        }
    }
    public void NextScene()
    {
        loadScript.Load(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.Save();
    }
    public void AnaMenu()
    {
        SceneManager.LoadScene(0);
    }
}
