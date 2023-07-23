using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField] private AudioSource collect;

    private void Start()
    {
        // Get reference to the MeshRenderer component
        meshRenderer = GetComponent<MeshRenderer>();



        int rand = Random.Range(0, 100);

        if (rand > 80)
        {
            // Enable the MeshRenderer
            if (meshRenderer != null)
            {
                meshRenderer.enabled = true;
            }
        }
        else
        {

        }
    }

    
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ball"))
    //    {
    //        // Disable the GameObject this script is attached to
    //        gameObject.SetActive(false);
    //    }
    //    collect.Play();
    //}
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Ball")
        {
            if (meshRenderer.enabled == true) {
                collect.Play();
                meshRenderer.enabled = false;
            }
            
        }

        if (target.tag == "Collectible")
        {
            //collect.Play();
        }
    }

}
