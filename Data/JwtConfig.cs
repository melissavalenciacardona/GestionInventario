namespace LabSoft.Data
{
    public class JwtConfig
    {
        public string Secret { get; set; }
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }

        public JwtConfig() { 
            Secret = string.Empty;
            ValidAudience = string.Empty;
            ValidIssuer = string.Empty;
        }

    }
}
