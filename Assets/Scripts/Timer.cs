public class Timer {
    public float Time { get; private set; }
    public float Cooldown;

    public bool IsTime() {
        if (countOn && Time == 0f) {
            countOn = false;
            return true;
        }
        return false;
    }

    public Timer(float cooldown) {
        Cooldown = cooldown;
    }

    public void DecreaseTime(float timeDelta) {
        Time -= timeDelta;
        if (Time < 0f)
            Time = 0f;
    }

    private bool countOn = false;
    public void BeginCount() {
        countOn = true;
        Time = Cooldown;
    }
}
