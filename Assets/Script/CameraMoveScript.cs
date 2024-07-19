using System.Collections;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    [SerializeField]
    private float hiz;
    private Vector3 baslangicPozisyon;
    private Vector3 bitisPozisyon;
    private void Start()
    {
        baslangicPozisyon = this.gameObject.transform.position;
        bitisPozisyon = this.gameObject.transform.position;
    }
    private void FixedUpdate()
    {
            if (this.gameObject.transform.position == baslangicPozisyon)
            {
                bitisPozisyon.x += 1;
                baslangicPozisyon = bitisPozisyon;

                if (!gameObject.CompareTag("MainCamera"))
                {
                    if (baslangicPozisyon == bitisPozisyon)
                        bitisPozisyon = this.gameObject.transform.position;
                }
            }
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, baslangicPozisyon, Time.deltaTime * hiz);
    }
}
