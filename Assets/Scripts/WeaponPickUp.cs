using UnityEngine;
using System.Collections;

public class WeaponPickUp : MonoBehaviour {

    public Weapon pickUpWeapon;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<GunController>().EquipWeapon(pickUpWeapon);
            Destroy(this.gameObject);
        }
    }
}
