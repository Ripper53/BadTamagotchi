using UnityEngine;
using UnityEngine.UI;

public class OwnerUI : MonoBehaviour {
    public Owner Owner;

    [Header("UI")]
    public Button FeedButton;

    public void FeedPet() {
        Owner.Pet.Feed(1);
    }
}
