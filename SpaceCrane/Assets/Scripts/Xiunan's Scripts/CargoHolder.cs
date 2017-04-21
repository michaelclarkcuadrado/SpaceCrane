using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoHolder : MonoBehaviour {

    public string placingInputSetting;

    GameObject cargo;   
    bool isActive;      //the cargo is holding cargo or not

    Transform cargoHolderTransform;

	void Start ()
    {
        isActive = false;
        cargoHolderTransform = this.GetComponent<Transform>();
	}

    public bool getActive()
    {
        return isActive;
    }

    public void setActive(bool active)
    {
        isActive = active;
    }

    public void repositionCargo()
    {
        cargo.transform.SetParent(cargoHolderTransform);
        cargo.transform.position = cargoHolderTransform.position + new Vector3(0f, 10f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cargo"))
        {
            
        }
    }
}
