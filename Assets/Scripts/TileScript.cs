using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    private Rigidbody myBody;
    [SerializeField]private AudioSource audio;
    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();

    }

    IEnumerator TriggerFallingDown()
    {
        yield return new WaitForSeconds(0.3f);
        myBody.isKinematic = false;
        audio.Play();
        StartCoroutine(TurnOffGameObject());
    }

    IEnumerator TurnOffGameObject()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    void OnTriggerExit(Collider target)
    {
        if (target.tag == "Ball")
        {
            StartCoroutine(TriggerFallingDown());
        }
    }
}
