using System;
using UnityEngine;

public class Requests
{
    
}


[Serializable]
public class RegisterRequest
{
    public string login;
    public string password;
}

[Serializable]
public class LoginRequests
{
    public string login;
    public string password;
}

[Serializable]
public class AuthResponse
{
    public bool status;
    public int userId;
}

[Serializable]
public class AuthResponses
{
    public bool status;
    public int userId;
}

[Serializable]
public class CoinsResponse
{
    public int coins;
}

[Serializable]
public class AddCoinsRequest
{
    public int userId;
    public int amount;
}

[Serializable]
public class BuySkinRequest
{
    public int userId;
    public int skinId;
}

[Serializable]
public class SelectSkinRequest
{
    public int userId;
    public int skinId;
}

[Serializable]
public class BuySkinResponse
{
    public bool status;
    public int coins;
}

[Serializable]
public class SelectedSkinResponse
{
    public int skinId;
    public string name;
}

[Serializable]
public class SkinItem
{
    public int skinId;
    public string name;
    public int? price;
    public bool isPurchased;
    public bool isSelected;
}

[Serializable]
public class SkinsResponse
{
    public SkinItem[] skins;
}

[Serializable]
public class SimpleResponse
{
    public bool status;
}