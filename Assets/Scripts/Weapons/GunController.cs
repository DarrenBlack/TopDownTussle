using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunController : MonoBehaviour {

    public Weapon currentlyEquipped;
    public bool isFiring;
    bool triggerLifted;    


    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
        if (currentlyEquipped != null)
        {
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

    public void EquipWeapon(Weapon newWeapon)
    {
        UnEquipWeapon();
        currentlyEquipped = Instantiate(newWeapon, gameObject.transform.position + newWeapon.transform.position, gameObject.transform.rotation) as Weapon;
        currentlyEquipped.transform.parent = gameObject.transform;
    }

    public void UnEquipWeapon()
    {
        if (currentlyEquipped != null)
        {
            currentlyEquipped.SelfDestruct();
            currentlyEquipped = null;
        }
    }
}
