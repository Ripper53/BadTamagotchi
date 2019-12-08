using UnityEngine;
using UnityEngine.UI;

public class PetAnimator : MonoBehaviour {
    public Pet Pet;
    public PetMovement PetMovement;
    public Animator Animator;
    public GameObject SpriteObj, GameOverObj;
    public Button[] PetButtons;

    public Image HealthBar, HygieneBar;

    [Header("Particle Systems")]
    public ParticleSystem ExplodeParticleSystem;

    public const string HappyTriggerName = "Happy", WalkBoolName = "Walk";

    private void Awake() {
        Pet.Healed += Pet_Happy;

        Pet.Died += Pet_Died;

        Pet_HealthChanged(Pet, 0);

        Pet.Healed += Pet_HealthChanged;
        Pet.Damaged += Pet_HealthChanged;

        Pet.Hygiene.Added += Stamina_Added;
        Pet.Hygiene.Removed += Stamina_Removed;
    }

    private void OnDestroy() {
        Pet.Healed -= Pet_Happy;

        Pet.Died -= Pet_Died;

        Pet.Healed -= Pet_HealthChanged;
        Pet.Damaged -= Pet_HealthChanged;

        Pet.Hygiene.Added -= Stamina_Added;
        Pet.Hygiene.Removed -= Stamina_Removed;
    }

    private readonly Timer happyTimer = new Timer(1f);
    private void Update() {
        happyTimer.DecreaseTime(Time.deltaTime);

        Animator.SetBool(WalkBoolName, PetMovement.Walking);

        if (happyTimer.IsTime())
            PetMovement.Stun = false;
    }

    private void Pet_Happy(Pet source, int amount) {
        PetMovement.Stun = true;
        happyTimer.BeginCount();
        Animator.SetTrigger(HappyTriggerName);
    }

    private void Pet_Died(Pet source) {
        Destroy(this);
        Pet_HealthChanged(source, 0);
        PetMovement.enabled = false;
        Animator.enabled = false;
        SpriteObj.SetActive(false);
        foreach (Button btn in PetButtons)
            btn.interactable = false;

        ExplodeParticleSystem.Play();

        GameOverObj.SetActive(true);
    }

    private void Pet_HealthChanged(Pet source, int amount) {
        HealthBar.fillAmount = (float)source.Health / source.MaxHealth;
    }

    private void Stamina_Added(ResourceData source, int addedAmount) {
        Animator.SetTrigger(HappyTriggerName);
        SetHygieneBar();
    }

    private void Stamina_Removed(ResourceData source, int removedAmount) {
        SetHygieneBar();
    }

    private void SetHygieneBar() {
        HygieneBar.fillAmount = (float)Pet.Hygiene.Value / Pet.Hygiene.Max;
    }
}
