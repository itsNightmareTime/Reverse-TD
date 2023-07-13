using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

    [SerializeField] private string UnitTag;

    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("target: " + target);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * 2f);
        this.transform.up = target.transform.position - this.transform.position;


       DestroySelf(25);

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(UnitTag)) { 
            DestroySelf(0);
        }
    }

    private void DestroySelf(int time) { 
        Destroy(gameObject, time);
    }

    public void getTarget(GameObject unit) {
        target = unit;
    }
}
