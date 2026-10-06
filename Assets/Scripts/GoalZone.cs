using UnityEngine;

public class GoalZone : MonoBehaviour
{
    [SerializeField] private Transform goalPoint;
    [SerializeField] private Renderer zoneRenderer;
    [SerializeField] private Color winColor = Color.green;

    private bool finished = false;

    public void DeliverItem(GameObject item, PickItem playerPick)
    {
        if (finished) return;
        if (item == null) return;

        PlaceAndWin(item);
    }

    private void PlaceAndWin(GameObject item)
    {
        item.transform.SetParent(goalPoint);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;

        Collider col = item.GetComponent<Collider>();
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (col!= null) col.enabled = true;
        if (rb!= null) rb.isKinematic = true; // queda fijo

        if (zoneRenderer!= null) zoneRenderer.material.color = winColor;

        finished = true;
        Debug.Log("¡Victoria, Key depositado dentro de Goal!");
    }
}