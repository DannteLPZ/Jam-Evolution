using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInvoker : MonoBehaviour
{
    public void InvokeEvent(GameEvent gameEvent) => gameEvent.Invoke();
}
