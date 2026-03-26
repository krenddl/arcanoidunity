using System;
using UnityEngine;

public class Requests
{
    
}


[Serializable]
public class RegisterRequest
{
    public string Login;
    public string Password;
}

[Serializable]
public class LoginRequests
{
    public string Login;
    public string Password;
}

[Serializable]
public class AuthResponse
{
    public bool Status;
    public int UserId;
}

[Serializable]
public class AuthResponses
{
    public bool Status;
    public int UserId;
}

[Serializable]
public class CoinsResponse
{
    public int Coins;
}

[Serializable]
public class AddCoinsRequest
{
    public int UserId;
    public int Amount;
}

[Serializable]
public class BuySkinRequest
{
    public int UserId;
    public int SkinId;
}

[Serializable]
public class SelectSkinRequest
{
    public int UserId;
    public int SkinId;
}

[Serializable]
public class BuySkinResponse
{
    public bool Status;
    public int Coins;
}

[Serializable]
public class SelectedSkinResponse
{
    public int SkinId;
    public string Name;
}

[Serializable]
public class SkinItem
{
    public int SkinId;
    public string Name;
    public int Price;
    public bool IsPurchased;
    public bool IsSelected;
}

[Serializable]
public class SkinsResponse
{
    public SkinItem[] Skins;
}

[Serializable]
public class SimpleResponse
{
    public bool Status;
}