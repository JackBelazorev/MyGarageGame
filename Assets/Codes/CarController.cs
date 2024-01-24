using UnityEngine;

public class CarController : MonoBehaviour
{
    private Animator carAnimator;
    private bool isWaitingForPlayerAction = false;

    void Start()
    {
        carAnimator = GetComponent<Animator>();
        carAnimator.SetBool("IsArrived", true);
    }

    void Update()
    {
        if (isWaitingForPlayerAction)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                carAnimator.SetTrigger("LeaveTrigger");
                carAnimator.SetTrigger("IsWaitingForPlayerAction");
                isWaitingForPlayerAction = false;
            }
        }
    }

    public void OnArriveAnimationEnd()
    {
        isWaitingForPlayerAction = true;
    }



    public void OnWaitForPlayerActionAnimationEnd()
    {
        carAnimator.SetTrigger("LeaveTrigger");
    }

    public void OnLeaveAnimationEnd()
    {
        // Убираем вызов PlayExitAnimation, чтобы избежать бесконечного цикла
        // PlayExitAnimation();

        // Здесь вы можете добавить другие действия после окончания анимации ухода
        Destroy(gameObject); // Уничтожаем объект машины
    }

    public void PlayArrivalAnimation()
    {
        if (carAnimator != null)
        {
            carAnimator.SetTrigger("ArrivalTrigger");
        }
        else
        {
            Debug.LogError("Animator component is not initialized on the car object.");
        }
    }

    public void PlayExitAnimation()
    {
        carAnimator.SetTrigger("LeaveTrigger");
    }
}
