using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    private Transform bar;

    // Start is called before the first frame update
    private void Start()
    {
        bar = transform.Find("Bar");
        //bar.localScale = new Vector3(0.4f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

}
