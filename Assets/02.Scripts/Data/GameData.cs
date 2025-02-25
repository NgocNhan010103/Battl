using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserDeepData
{
    public string UserName;
    public string Password;
    public string Email;
    public int Coins;
    public int Diamonds;
    public int Day;
    public int PointDActive;
    public int PointWActive;
    public DateTime lastCheckedDate;
    public List<QuestData> QuestesDaily;
    public List<QuestData> QuestesWeekly;
}

[System.Serializable]
public class PlayerData
{
    public int ID;
    public string Name;
    public int MaxHealth;
    public int Damage;
    public int Defence;
    public List<Item> Items;
    public GameObject CharacterPrefab;
    public WeaponDetail WeaponDetail;
}

[System.Serializable]
public class WeaponDetail   
{
    public int Damage;
    public float Speed;
    public float Ammo;
}

[System.Serializable]
public class MonsterData
{
    public int ID;
    public string Name;
    public int Damage;
    public float MoveSpeed;
    public float AttackSpeed;
    public int MaxHealth;
}

[System.Serializable]
public class Inventory
{
    public List<Item> ItemsInInventory;
}

[System.Serializable]
public class InventorySlotData
{
    public int ID;
    public Item ItemInSlot;

}

[System.Serializable]
public class Item
{
    public int ID;
    public string Name;
    public string Description;
    public int Level;
    public int DamageBonus;
    public int HealthBonus;
    public int DefenceBonus;
}


[System.Serializable]
public class QuestData
{
    public int ID;
    public string Name;
    public string Description;
    public int CurQuality;
    public int Quality;
    public int PointActive;
    public int CoinsForClaim;
    public QuestType QType;
    public QuestState QState;
    public bool IsClaimed;
}
public class UserData
{
    public static UserDeepData data;


    public static void SaveData()
    {
        PlayerPrefs.SetString(GameData.PP_USER_DATA, JsonConvert.SerializeObject(data));
    }
}

public class GameData
{
    public const string PP_USER_DATA = "UserDataPrefab";
}
