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
        rotateTower(); 
    }

    public void rotateTower() {
        TowerVisual.transform.Rotate(Vector3.forward);
        //TowerVisual.transform.Rotate(new Vector3(0,0,1));
    }
}
