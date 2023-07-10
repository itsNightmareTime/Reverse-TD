using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControls : MonoBehaviour
{
    [SerializeField] private GameObject TowerVisual;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turnClockwise(); 
    }

    public void turnCounterClockwise() {
        TowerVisual.transform.Rotate(Vector3.forward);
    }

    public void turnClockwise() {
        TowerVisual.transform.Rotate(Vector3.back);
    }
}
