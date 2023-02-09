namespace e_commerceBackEnd.Model
{
    public class AuthRusult
    {
        public string Token { get; set; }
        public bool Result { get; set; }
        public List<string> Error { get; set; }

    }
}
