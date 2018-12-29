using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ES3.Save<int>("myInteger",123);
        ES3.Save<float>("hello",123131f);
        int myInteger = ES3.Load<int>("myInteger");
        Debug.Log(myInteger);
        Debug.Log(Application.persistentDataPath);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
