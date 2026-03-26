using UnityEngine;

public static class UserSession
{
    public static int UserId;
    public static bool IsAuth => UserId > 0;
}
