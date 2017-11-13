using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	public GameObject selectedZombie;
	public List<GameObject> zombies;
	private int selectedZombieIndex=0;
	public Text scoreText;
	public Vector3 defaultScale;
	public Vector3 selectedScale;
	private int score=0;
	void Start () {
		SelectedZombie (selectedZombie);
		scoreText.text = "Score: " + score;
	}
	void SelectedZombie(GameObject newZombie)
	{
		selectedZombie.transform.localScale = defaultScale;
			selectedZombie=newZombie;
		newZombie.transform.localScale = selectedScale;
	}
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown ("left")) {
			SelectLeftZombie ();
			SelectedZombie (zombies[selectedZombieIndex]);
		}
		if (Input.GetKeyDown ("right")) {
			SelectRightZombie ();
			SelectedZombie (zombies[selectedZombieIndex]);
		}
		if (Input.GetKeyDown ("up")) {
			PushUp ();
		}
	}
	void SelectLeftZombie()
	{
		if (selectedZombieIndex == 0) 
			selectedZombieIndex = 3;
		else
			selectedZombieIndex--;
	}
	void SelectRightZombie()
	{
		if (selectedZombieIndex == 3) 
			selectedZombieIndex = 0;
		else
			selectedZombieIndex++;
	}
	void PushUp()
	{
		Rigidbody rb = selectedZombie.GetComponent<Rigidbody> ();
		rb.AddForce (0, 0, 10, ForceMode.Impulse);
	}
	public void IncrementScore()
	{
		score += 1;
		scoreText.text = "Score: " + score;
	}
}
