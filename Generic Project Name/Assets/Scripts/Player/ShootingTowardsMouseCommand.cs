using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Command;

namespace Player.Command
{
    public class ShootingTowardsMouseCommand : ScriptableObject, IPlayerCommand<GameObject>
    {

        public void Execute(GameObject gameObject)
        {
            testWeaponController weaponController = gameObject.GetComponentInChildren<testWeaponController>();

            if (weaponController == null)
            {
                Debug.LogError("Test Weapon Controller not found!");
            }
        }
    }
}