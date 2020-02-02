using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterModule : CarriableObject
{
    public ParticleSystem effect;

    public override void OnEquip(CharacterHands characterHands)
    {
        base.OnEquip(characterHands);

        characterHands.GetComponent<BaseCharacterController>().hasDoubleJump = true;
    }

    public override void OnUnequip(CharacterHands characterHands)
    {
        base.OnUnequip(characterHands);

        characterHands.GetComponent<BaseCharacterController>().hasDoubleJump = false;
    }

    public void PlayEffect()
    {
        effect.Play();
    }
}
