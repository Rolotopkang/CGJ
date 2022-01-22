using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour {
    List<HeldItem> heldItems;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void addItemToBag(HeldItem item) {
        this.heldItems.Add(item);
    }

    public void dropItemFromBag(HeldItem item) {
        this.heldItems.Remove(item);
    }

    public List<HeldItem> getHeldItems() {
        return this.heldItems;
    }
}
