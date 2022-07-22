namespace delivery_system_api.Resources
{
    public class AuthenticatedUserResource
    {
        public int id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string IdToken { get; set; } 
        public string RefreshToken { get; set; }    
        public DateTime ExpiresIn   { get; set; }   
    }
}
