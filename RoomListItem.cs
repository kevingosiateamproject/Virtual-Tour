using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.Match;

public class RoomListItem : MonoBehaviour {

    // A delegate is a type that represents references to methods with a particular parameter list and return type.
    public delegate void JoinRoomDelegate(MatchInfoSnapshot _room);
    // Instance of JoinRoomDelegate
    private JoinRoomDelegate joinRoomCallback;

    [SerializeField]
    private Text roomNameText;

    private MatchInfoSnapshot room;

    public void Setup(MatchInfoSnapshot _room, JoinRoomDelegate _joinRoomCallback)
    {
        room = _room;
        joinRoomCallback = _joinRoomCallback;

        roomNameText.text = room.name + " (" + room.currentSize + "/" + room.maxSize + ")";
    }

    public void JoinRoom()
    {
        joinRoomCallback.Invoke(room);
    }
}
