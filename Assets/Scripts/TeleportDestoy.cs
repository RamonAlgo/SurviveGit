using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDestoy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destrueixObjecte", 1f);
    }

    private void destrueixObjecte()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
