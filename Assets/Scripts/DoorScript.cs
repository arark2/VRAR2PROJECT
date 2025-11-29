using System.Collections;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [Header("Door Settings")]
<<<<<<< HEAD
    public float openAngle = 90f;     // 문이 열릴 각도 (+90 / -90)
    public float openSpeed = 4f;      // 열리는/닫히는 속도
=======
    public float openAngle = 90f;
    public float openSpeed = 4f;
>>>>>>> b545e79 (Initial commit)

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
<<<<<<< HEAD

        // 항상 같은 방향으로만 열림
=======
>>>>>>> b545e79 (Initial commit)
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
    }

    void Update()
    {
<<<<<<< HEAD
        float dist = Vector3.Distance(player.position, transform.position);

        // 플레이어 가까이 오면 열기
=======
        // player가 아직 할당되지 않았다면 씬에서 찾아보기
        if (player == null)
        {
            player = GameObject.FindWithTag("Player")?.transform;
            if (player == null) return; // 그래도 없으면 넘어감
        }

        float dist = Vector3.Distance(player.position, transform.position);

>>>>>>> b545e79 (Initial commit)
        if (!isOpen && dist <= activateDistance)
        {
            if (routine != null) StopCoroutine(routine);
            routine = StartCoroutine(OpenDoor());
        }
<<<<<<< HEAD
        // 멀어지면 닫기
=======
>>>>>>> b545e79 (Initial commit)
        else if (isOpen && dist > activateDistance)
        {
            if (routine != null) StopCoroutine(routine);
            routine = StartCoroutine(CloseDoor());
        }
    }
<<<<<<< HEAD

=======
    
>>>>>>> b545e79 (Initial commit)
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
