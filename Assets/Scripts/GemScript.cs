using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    [SerializeField] private GameObject sparkleFx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.tag == "Ball")
        {
            Instantiate(sparkleFx, transform.position, Quaternion.identity);
            GamePlayController.instance.PlayCollectibleSound();
            gameObject.SetActive(false);
        }
    }
}
