using UnityEngine;

public class PetColorSetter : MonoBehaviour {
    public static Color
        HeadColor = new Color(1f, 1f, 1f),
        BodyColor = new Color(1f, 1f, 1f),
        LeftEyeColor = new Color(0f, 0f, 0f), RightEyeColor = new Color(0f, 0f, 0f),
        MouthColor = new Color(0f, 0f, 0f),
        LeftArmColor = new Color(1f, 1f, 1f), RightArmColor = new Color(1f, 1f, 1f),
        LeftLegColor = new Color(1f, 1f, 1f), RightLegColor = new Color(1f, 1f, 1f);

    public SpriteRenderer
        Head,
        Body,
        LeftEye, RightEye,
        Mouth,
        LeftArm, RightArm,
        LeftLeg, RightLeg;

    private void Awake() {
        Head.color = HeadColor;
        Body.color = BodyColor;
        LeftEye.color = LeftEyeColor;
        RightEye.color = RightEyeColor;
        Mouth.color = MouthColor;
        LeftArm.color = LeftArmColor;
        RightArm.color = RightArmColor;
        LeftLeg.color = LeftLegColor;
        RightLeg.color = RightLegColor;
    }
}
