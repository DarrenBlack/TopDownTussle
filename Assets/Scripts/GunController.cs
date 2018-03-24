using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

    public Weapon currentlyEquipped;
    public bool isFiring;
    bool triggerLifted;
	
	// Update is called once per frame
	void Update () {
        if (isFiring)
        {
            currentlyEquipped.Fire();
        }
        else
        {
            currentlyEquipped.TriggerLifted();
        }
        
	}
}
