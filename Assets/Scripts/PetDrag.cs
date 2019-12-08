using UnityEngine;
using UnityEngine.EventSystems;

public class PetDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public PetMovement PetMovement;
    public Camera Camera;

    public void OnBeginDrag(PointerEventData eventData) {
        PetMovement.Stun = true;
        PetMovement.RB.gravityScale = 0f;
    }

    public void OnDrag(PointerEventData eventData) {
        Vector2 pos = Camera.ScreenToWorldPoint(eventData.position);
        PetMovement.RB.MovePosition(pos);
        PetMovement.RB.velocity = new Vector2(0f, 0f);
    }

    public void OnEndDrag(PointerEventData eventData) {
        PetMovement.RB.gravityScale = 1f;
        PetMovement.Stun = false;
    }
}
