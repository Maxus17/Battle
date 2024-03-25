using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeCaster : MonoBehaviour
{
    public Rigidbody grenadePrefab;
    public Transform grenadeTransform;

    public float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var grenade=Instantiate(grenadePrefab);
            grenade.transform.position = grenadeTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(grenadeTransform.forward*force);
        }
    }
}
