using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public GameObject path;
	public float speed;
	public float threshold;
	private Node[] trajectory;
	private Node current;
	private int currentI;

	// Use this for initialization
	void Start () {
		trajectory = path.GetComponentsInChildren<Node>();
		current = trajectory[0];
		currentI = 0;
		StartCoroutine (CheckIfChange ());
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(current.transform);
		transform.rotation = new Quaternion(0,0,transform.rotation.z,0);
		transform.position = Vector2.MoveTowards(transform.position, current.transform.position, Time.deltaTime * speed);
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
