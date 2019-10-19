using System.Collections;
using UnityEngine;

public class OrbSpawn : MonoBehaviour {

    OrbSpawn instance;

    [SerializeField]
    GameObject[] orbs = new GameObject[4];

    Ray ray; //we need a ray
    RaycastHit hitInfo; //we need an intersection point info

    public bool[] accessListForLevels = new bool[10];

    //we will add orb count limitation for each level later

    void Start()
    {  
        if(instance == null) { instance = this; }    
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetTheOrb();
        }
    }

    void SetTheOrb()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo))
        {
            int orbKind = Mathf.FloorToInt(Random.Range(0, 4));
            Instantiate(orbs[orbKind], new Vector3(hitInfo.point.x, hitInfo.point.y, 0), Quaternion.identity);
        }
    }


    void CheckGameEndedOrNot()
    {
        //this one will check the game or not
    }

    IEnumerator WaitBeforeGameFinished()
    {
        yield return new WaitForSeconds(2f); //it will be inside CheckGameEndedOrNot
    }

}
