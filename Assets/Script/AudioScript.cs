using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private string clipName;
    private void Awake()
    {
        clipName = this.gameObject.GetComponent<AudioSource>().clip.name;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
        {
            if (objs[objs.Length - 2].GetComponent<AudioSource>().clip.name == clipName & clipName != "araSahneMusic")
                Destroy(this.gameObject);
            else
                Destroy(objs[objs.Length - 2]);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
