using UnityEngine;

public class Pet : MonoBehaviour {
    public Transform Transform;
    public Owner Owner;
    [SerializeField]
    private int _health, _maxHealth;
    public int Health { get => _health; private set => _health = value; }
    public int MaxHealth { get => _maxHealth; private set => _maxHealth = value; }

    public ResourceData Hygiene;

    public Poop PoopPrefab;

    private readonly Timer
        hygieneZeroTimer = new Timer(2f),
        feedTimer = new Timer(0f),
        quickFeedTimer = new Timer(1f),
        healthDecayTimer = new Timer(0f);
    private int
        feedCount = 0,
        quickFeedCount = 0;

    private void Awake() {
        SetHealthDecayCooldown();
    }

    private void SetHealthDecayCooldown() {
        healthDecayTimer.Cooldown = Random.Range(5f, 10f);
        healthDecayTimer.BeginCount();
    }

    private void SetFeedPoopCooldown() {
        feedTimer.Cooldown = Random.Range(5f, 10f);
        feedTimer.BeginCount();
    }

    private void Update() {
        hygieneZeroTimer.DecreaseTime(Time.deltaTime);
        feedTimer.DecreaseTime(Time.deltaTime);
        quickFeedTimer.DecreaseTime(Time.deltaTime);
        healthDecayTimer.DecreaseTime(Time.deltaTime);

        if (hygieneZeroTimer.IsTime())
            Damage(1);
        if (Hygiene.Value == 0 && hygieneZeroTimer.Time == 0f)
            hygieneZeroTimer.BeginCount();

        if (feedTimer.IsTime()) {
            Poop();
            if (feedCount > 0)
                SetFeedPoopCooldown();
        }

        if (quickFeedTimer.IsTime())
            quickFeedCount = 0;
        else if (quickFeedCount > 5)
            Die();

        if (healthDecayTimer.IsTime()) {
            SetHealthDecayCooldown();
            Damage(1);
        }


    }

    private void Check() {
        if (Health <= 0) {
            Die();
        } else if (Health > MaxHealth) {
            Health = MaxHealth;
        }
    }

    public delegate void DamagedAction(Pet source, int damage);
    public event DamagedAction Damaged;
    public void Damage(int damage) {
        Health -= damage;
        Damaged?.Invoke(this, damage);
        Check();
    }

    public delegate void HealedAction(Pet source, int heal);
    public event HealedAction Healed;
    public void Heal(int heal) {
        Health += heal;
        Healed?.Invoke(this, heal);
        Check();
    }

    public delegate void DiedAction(Pet source);
    public event DiedAction Died;
    public void Die() {
        Health = 0;
        enabled = false;
        Died?.Invoke(this);
    }

    public void Feed(int amount) {
        feedCount++;
        if (feedTimer.Time == 0f)
            SetFeedPoopCooldown();
        quickFeedCount++;
        quickFeedTimer.BeginCount();
        Heal(amount);
    }

    public void Poop() {
        feedCount--;
        if (feedCount < 0)
            feedCount = 0;
        Hygiene.Remove(1);
        Poop poop = Instantiate(PoopPrefab, Transform.position, Quaternion.identity);
        poop.Owner = Owner;
        poop.Canvas.worldCamera = Owner.Camera;
    }
}
