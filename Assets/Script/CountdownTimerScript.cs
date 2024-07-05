using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownTimerScript : MonoBehaviour
{
    private int timeValue;
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private GameObject countdownPanel;
    [SerializeField]
    private GameObject anaPanel;
    private GameObject kamera;
    private int textRotation;
    [SerializeField]
    private AudioSource tick;

    void Start()
    {
        timeValue = 3;
        textRotation = 180;
        anaPanel.SetActive(false);
        countdownPanel.SetActive(true);
        kamera = GameObject.FindWithTag("MainCamera");
        kamera.GetComponent<PlatformHareketScript>().enabled = false;
        StartCoroutine(Countdown());
    }
    private IEnumerator Countdown()
    {
        while(timeValue>0)
        {
            timeText.gameObject.transform.rotation = Quaternion.Euler(0, 0, textRotation);
            textRotation += 90;
            timeText.text = timeValue.ToString();
            tick.Play();
            yield return new WaitForSeconds(1f);
            timeValue -= 1;
        }
        countdownPanel.SetActive(false);
        anaPanel.SetActive(true);
        kamera.GetComponent<PlatformHareketScript>().enabled = true;
    }
}
