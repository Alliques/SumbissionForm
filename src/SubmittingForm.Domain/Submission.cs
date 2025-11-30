using System.Text.Json;

namespace SubmittingForm.Domain
{
    public class Submission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public JsonElement Payload { get; set; }
    }
}
