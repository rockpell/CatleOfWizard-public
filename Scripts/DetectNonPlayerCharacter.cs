using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectNonPlayerCharacter : MonoBehaviour {
    [SerializeField] EnemyCharacterManager enemyManager;
	[SerializeField] private GameObject playHitPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "RunningNPC")
		{
			NonPlayerCharacter nonPlayer = other.gameObject.GetComponent<NonPlayerCharacter>();
			other.gameObject.tag = "EscapeNPC";
			StartCoroutine(nonPlayer.ChangeState());
		}
        if(other.tag == "Enemy")
        {
            EnemyCharacter nonPlayer = other.gameObject.GetComponent<EnemyCharacter>();
            other.gameObject.tag = "AttackEnemy";

			nonPlayer.ChangeState(playHitPoint/*나중에 VR에 맞춰서 바꿔야함*/);
        }
    }
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "RunningNPC")
		{
			NonPlayerCharacter nonPlayer = other.gameObject.GetComponent<NonPlayerCharacter>();
			other.gameObject.tag = "EscapeNPC";
			StartCoroutine(nonPlayer.ChangeState());
		}
		if (other.tag == "Enemy")
		{
			EnemyCharacter nonPlayer = other.gameObject.GetComponent<EnemyCharacter>();
			other.gameObject.tag = "AttackEnemy";

			nonPlayer.ChangeState(playHitPoint/*나중에 VR에 맞춰서 바꿔야함*/);
		}
	}
	private void OnTriggerExit(Collider other)
    {
		if (other.transform.parent == null)
		{
			if (other.tag == "AttackEnemy")
			{
				EnemyCharacter nonPlayer = other.gameObject.GetComponent<EnemyCharacter>();
				other.gameObject.tag = "Enemy";
				nonPlayer.RestartFollowPoint();
			}
		}
		else
		{
			if (other.transform.parent.tag == "AttackEnemy")
			{
				EnemyCharacter nonPlayer = other.transform.parent.GetComponent<EnemyCharacter>();
				other.transform.parent.tag = "Enemy";
				nonPlayer.RestartFollowPoint();
			}
		}
    }
}
