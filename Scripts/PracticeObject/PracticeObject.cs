using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeObject : MonoBehaviour {

    private int positionId = 0;

	// Use this for initialization
	void Start () {
		
	}

    private void OnDestroy()
    {
        GameObject _temp = GameObject.Find("PracticeObjectManager");
        if (_temp != null)
        {
            _temp.GetComponent<PracticeObjectManager>().DeadPracticeObject(positionId);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "magic")
        {
            Destroy(this.gameObject);
        }
    }

    public int PositionId
    {
        get { return positionId; }
        set { positionId = value; }
    }
}
