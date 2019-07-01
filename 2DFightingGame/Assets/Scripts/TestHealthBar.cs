using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealthBar : MonoBehaviour
{

    [SerializeField] private HealthBar healthBar;
    public float barSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetSize(1f);
    }

    // Update is called once per frame
    void Update()
    {
      healthBar.SetSize(barSize);  

      if(Input.GetButtonDown("Jump") == true)
      {
        barSize -= 0.2f;
      }
    }
}
