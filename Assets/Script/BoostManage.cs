using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoostManage : MonoBehaviour {

	public Slider BoostSlider;
	public static bool IsZero=false;

	void Update () {
		if (movement.tempspeed) {
			BoostSlider.value = Mathf.MoveTowards (BoostSlider.value, 1.0f, -0.0025f);
			if (BoostSlider.value==0)
			{
				IsZero = true;
			}
		} 

		else {
			BoostSlider.value = Mathf.MoveTowards (BoostSlider.value, 1.0f, 0.001f);
			IsZero = false;
		}
	}
}
