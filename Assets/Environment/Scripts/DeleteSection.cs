using System.Collections;
using UnityEngine;

public class DeleteSection : MonoBehaviour
{
    private void OnTriggerEnter(Collider player)
    {
        StartCoroutine(DeleteWait());
    }

    IEnumerator DeleteWait()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }
}
