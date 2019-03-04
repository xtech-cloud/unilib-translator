using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XTC.Text;

public class Sample : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Translator.MergeFromResource("test", true);
		Debug.Log(Translator.Translate("0001"));
		Translator.language = "zh_CN";
		Debug.Log(Translator.Translate("0001"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
