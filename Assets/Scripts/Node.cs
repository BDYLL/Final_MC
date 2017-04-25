using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {

	public bool rotateRight;
	public bool rotateLeft;
	public bool bussy;
	public bool cashier;
	public int occupiedBy;
	public Node[] neighbors;
	public List<Node> history;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
        bussy = true;
        occupiedBy = other.gameObject.GetInstanceID();       
        /*
        if(rotateLeft){
	    	Quaternion rotation = Quaternion.Euler(0, 0, 90); // this add a 90 degrees Y rotation
	    	other.gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10.0f);
        }
        */
    }

    void OnTriggerExit(Collider other) {
        bussy = false;
        occupiedBy = 0;
        if(cashier && occupiedBy == other.gameObject.GetInstanceID()){
        	Destroy(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other){
    	bussy = true;
    }

	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(transform.position, 0.2f);
		Gizmos.color = Color.blue;
		for(int i = 0; i < neighbors.Length; i++){
			Gizmos.DrawLine (transform.position, neighbors [i].transform.position);
		}
	}
}
