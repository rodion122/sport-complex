namespace SportComplex
{
    public static class AuthorizationManager
    {
        static public string GetRole(string email, string password)
        {
            if (password == "1234")
            {
                return email;
            }

            return "";
        }
    }
}
