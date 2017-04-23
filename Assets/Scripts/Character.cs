using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public Node[] trajectory;
	public float threshold;
	private Node current;
	private int currentI;

	// Use this for initialization
	void Start () {
		current = trajectory [0];
		currentI = 0;
		StartCoroutine (CheckIfChange ());
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 targetPosition = (current.transform.rotation.x,current.transform.rotation.y,current.transform.rotation.z);
		//transform.LookAt (current.position);
		//transform.rotation = new Quaternion(0, 0, current.transform.rotation.z, 0);
		//transform.Translate (transform.forward * Time.deltaTime * 5, Space.World);
		//Vector3 targetPosition = new Vector3(10,20,30);
		transform.LookAt(current.transform);
		transform.rotation = new Quaternion(0,0,transform.rotation.z,0);
		transform.position = Vector2.MoveTowards(transform.position, current.transform.position, Time.deltaTime * 5);
	}

	IEnumerator CheckIfChange(){
		while (true) {
			float distance = Vector3.Distance (transform.position, current.transform.position);
			if (distance < threshold) {
				currentI++;
				currentI %= trajectory.Length;
				current = trajectory [currentI];
			}
			yield return new WaitForSeconds (0.02f);
		}
	}
}
