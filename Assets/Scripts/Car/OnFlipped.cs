using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFlipped : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Road")
        {
            StartCoroutine(FlippedBack());
            Debug.Log("Flipped");
        }
    }

    IEnumerator FlippedBack()
    {
        GameObject parentGO = gameObject.transform.parent.gameObject;
        yield return new WaitForSecondsRealtime(3f);
        parentGO.transform.position = new Vector3(parentGO.transform.position.x, 1.2f, parentGO.transform.position.z);
        parentGO.transform.rotation = Quaternion.Euler(0f, parentGO.transform.rotation.eulerAngles.y, 0f);
    }
}
