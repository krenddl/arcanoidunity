using UnityEngine;

public static class UserService
{
    public static int UserId;
    public static bool IsAuth => UserId != 0;
}