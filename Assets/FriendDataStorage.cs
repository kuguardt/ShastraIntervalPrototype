using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendDataStorage : MonoBehaviour
{
    public List<FriendData> friends;
    public static FriendDataStorage instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void RandomFriendsLocation()
    {
        List<int> locations = new List<int>();

        for (int i = 0; i < 7; i++)
        {
            locations.Add(i);
        }

        List<int> selectedPlace = new List<int>();
        int selectedCount = 0;
        while (selectedCount < friends.Count)
        {
            int randomizer = Random.Range(0, 7);
            if (!selectedPlace.Contains(randomizer))
            {
                selectedPlace.Add(randomizer);
                selectedCount++;
            }
        }

        for (int i = 0; i < friends.Count; i++)
        {
            friends[i].currentlocation = SceneLoader.instance.LocationEnumString(selectedPlace[i]);
        }
    }
}
