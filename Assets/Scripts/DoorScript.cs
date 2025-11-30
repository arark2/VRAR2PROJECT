using System.Collections;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [Header("Door Settings")]
    public float openAngle = 90f;     // 문이 열릴 각도 (+90 / -90)
    public float openSpeed = 4f;      // 열리는/닫히는 속도

    [Header("Player Detection")]
    public Transform player;
    public float activateDistance = 2.5f;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private bool isOpen = false;
    private Coroutine routine;

    void Start()
    {
        closedRotation = transform.rotation;

        // 항상 같은 방향으로만 열림
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
    }

    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);

        // 플레이어 가까이 오면 열기
        if (!isOpen && dist <= activateDistance)
        {
            if (routine != null) StopCoroutine(routine);
            routine = StartCoroutine(OpenDoor());
        }
        // 멀어지면 닫기
        else if (isOpen && dist > activateDistance)
        {
            if (routine != null) StopCoroutine(routine);
            routine = StartCoroutine(CloseDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        isOpen = true;

        while (Quaternion.Angle(transform.rotation, openRotation) > 0.01f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, openRotation, openSpeed * Time.deltaTime);
            yield return null;
        }

        transform.rotation = openRotation;
    }

    IEnumerator CloseDoor()
    {
        isOpen = false;

        while (Quaternion.Angle(transform.rotation, closedRotation) > 0.01f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, closedRotation, openSpeed * Time.deltaTime);
            yield return null;
        }

        transform.rotation = closedRotation;
    }
}
