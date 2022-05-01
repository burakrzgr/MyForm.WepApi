public enum ConclutionType
{
    Static = 0, // come operation is static such as create and cant be modified after
    Unresolved = 1, // waiting for concution
    Redirected = 3, //
    Received = 4,
    Rejected = 5,
    ReplyRead = 6
}