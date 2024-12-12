namespace ELearning.Request
{
    public class ForgotPasswordRequest
    {
        public string Email { get; set; }
        public string? Otp { get; set; }
        
    }
}
