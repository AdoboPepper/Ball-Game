using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    private Rigidbody myBody;
    [SerializeField]private AudioSource fall;

    [SerializeField]private GameObject gem;

    [SerializeField] private float chanceForCollectible;
    
    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        if (Random.value < chanceForCollectible)
        {
            Vector3 temp = transform.position;
            temp.y += 2f;
            Instantiate(gem, temp, Quaternion.identity);
        }
    }
    IEnumerator TriggerFallingDown()
    {
        yield return new WaitForSeconds(0.3f);
        myBody.isKinematic = false;
        fall.Play();
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

        if (target.tag == "Collectible")
        {
            //collect.Play();
        }
    }
}
