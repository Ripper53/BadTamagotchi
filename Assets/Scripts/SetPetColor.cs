using UnityEngine;

public class SetPetColor : MonoBehaviour {

    public PetColorPicker
        Head,
        Body,
        LeftEye, RightEye,
        Mouth,
        LeftArm, RightArm,
        LeftLeg, RightLeg;

    private void Awake() {
        Head.Color = PetColorSetter.HeadColor;
        Body.Color = PetColorSetter.BodyColor;
        LeftEye.Color = PetColorSetter.LeftEyeColor;
        RightEye.Color = PetColorSetter.RightEyeColor;
        Mouth.Color = PetColorSetter.MouthColor;
        LeftArm.Color = PetColorSetter.LeftArmColor;
        RightArm.Color = PetColorSetter.RightArmColor;
        LeftLeg.Color = PetColorSetter.LeftLegColor;
        RightLeg.Color = PetColorSetter.RightLegColor;
    }

    private void Update() {
        PetColorSetter.HeadColor = Head.Color;
        PetColorSetter.BodyColor = Body.Color;
        PetColorSetter.LeftEyeColor = LeftEye.Color;
        PetColorSetter.RightEyeColor = RightEye.Color;
        PetColorSetter.MouthColor = Mouth.Color;
        PetColorSetter.LeftArmColor = LeftArm.Color;
        PetColorSetter.RightArmColor = RightArm.Color;
        PetColorSetter.LeftLegColor = LeftLeg.Color;
        PetColorSetter.RightLegColor = RightLeg.Color;
    }
}
