using UnityEngine;
using Meta.XR.MRUtilityKit;
using System;

public class RoomController : MonoBehaviour
{
    [Header("Prefab que quieres colocar en el centro del suelo")]
    public GameObject roomPrefab;

    [Header("Altura extra sobre el suelo")]
    public float yOffset = 0.02f;

    [SerializeField] private GameObject spawnedRoom;

    public event Action OnRoomPlaced;

    private void Start()
    {
        Invoke(nameof(PlaceRoomInFloorCenter), 0.5f);
    }

    public void PlaceRoomInFloorCenter()
    {
        MRUKRoom currentRoom = MRUK.Instance.GetCurrentRoom();

        if (currentRoom == null)
        {
            Debug.LogWarning("No se ha encontrado ninguna habitación MRUK.");
            return;
        }

        MRUKAnchor floorAnchor = currentRoom.FloorAnchor;

        if (floorAnchor == null)
        {
            Debug.LogWarning("No se ha encontrado el suelo en MRUK.");
            return;
        }

        Vector3 floorCenter = floorAnchor.transform.position;
        floorCenter.y += yOffset;

        if (spawnedRoom == null)
        {
            spawnedRoom = Instantiate(roomPrefab, floorCenter, floorAnchor.transform.rotation);
        }
        else
        {
            spawnedRoom.transform.position = floorCenter;
            //spawnedRoom.transform.rotation = floorAnchor.transform.rotation;
        }

        OnRoomPlaced?.Invoke();

        Debug.Log("Room colocado en el centro del suelo.");
    }
}