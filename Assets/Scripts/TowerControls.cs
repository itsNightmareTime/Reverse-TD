using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControls : MonoBehaviour
{
    enum targetPriority {First, Last, Close, Strong };
    [SerializeField] private GameObject TowerVisual;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject ProjectilePos;
    [SerializeField] private GameObject unit;

    private targetPriority currentTargetPriority;

    void Awake()
    {
        currentTargetPriority = targetPriority.First;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ) {
            turnClockwise();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            turnCounterClockwise();
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) {
            shoot();
        }

        
    }

    public void turnCounterClockwise() {
        TowerVisual.transform.Rotate(Vector3.forward * 2);

    }

    public void turnClockwise() {
        TowerVisual.transform.Rotate(Vector3.back * 2);
    }

    public void shoot() {
        GameObject theProjectile = Instantiate(projectile, ProjectilePos.transform.position, Quaternion.identity);    
        theProjectile.transform.rotation = TowerVisual.transform.rotation;
        theProjectile.GetComponent<ProjectileBehaviour>().getTarget(unit);
    }

    public void upgrade() { 
    
    }

    public void sell() { 
    
    }

    public void setTargetPriority() { 
    
    }
}
