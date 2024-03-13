using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManagerScript : MonoBehaviour
{
    [SerializeField]
    private Slider yuklemeBar;
    [SerializeField]
    private GameObject anaPanel;
    [SerializeField]
    private GameObject yuklemePanel;
    public void Load(int level)
    {
        anaPanel.SetActive(false);
        yuklemePanel.SetActive(true);
        StartCoroutine(StartLoading(level));
    }
    IEnumerator StartLoading(int level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);
        while(!operation.isDone)
        {
            yuklemeBar.value = operation.progress;
            yield return null;
        }
    }
}
