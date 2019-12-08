using UnityEngine;
using UnityEngine.EventSystems;

public class PoopUI : MonoBehaviour, IPointerClickHandler {
    public Poop Poop;

    public void OnPointerClick(PointerEventData eventData) {
        Destroy(Poop.gameObject);
        Poop.Owner.Pet.Hygiene.Add(1);
    }
}
