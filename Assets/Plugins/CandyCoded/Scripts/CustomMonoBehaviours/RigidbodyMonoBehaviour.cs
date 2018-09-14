using UnityEngine;

public abstract class RigidbodyMonoBehaviour : MonoBehaviour
{

    protected Rigidbody rb;

    private bool sleepingState;

    protected virtual void Awake()
    {

        rb = gameObject.GetComponent<Rigidbody>();

    }

    private void OnCollisionStay()
    {

        if (rb != null && rb.IsSleeping() != sleepingState)
        {

            sleepingState = rb.IsSleeping();

            if (sleepingState)
            {

                OnCollisionSleep();

            }
            else
            {

                OnCollisionAwake();

            }

        }

    }

    protected abstract void OnCollisionSleep();

    protected abstract void OnCollisionAwake();

}
