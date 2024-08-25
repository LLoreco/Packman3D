using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Teleporter : MonoBehaviour
{
    public abstract void Teleport(GameObject target);
    public virtual void Initialize() { }
}
