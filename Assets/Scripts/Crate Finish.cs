using Unity.Cinemachine;
using UnityEngine;

public class CrateFinish : MonoBehaviour
{
    public GameObject attractorBeam;

    void Awake()
    {
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            collision.gameObject.GetComponentInChildren<Gravity>().enabled = true;
        }
    }
}
