using SubmittingForm.Domain;
using System.Text.Json;

namespace SubmittingForm.Application
{
    public class SubmissionService
    {
        private readonly ISubmissionRepository _repository;

        public SubmissionService(ISubmissionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CreateAsync(JsonElement payload)
        {
            var submission = new Submission { Payload = payload };
            await _repository.AddAsync(submission);
            return submission.Id;
        }

        public async Task<IEnumerable<Submission>> SearchAsync(string? query)
        {
            var all = await _repository.GetAllAsync();

            if (string.IsNullOrWhiteSpace(query))
            {
                return all.OrderByDescending(x => x.CreatedAt);
            }

            var lowerQuery = query.ToLower();
            return all
                .Where(x => x.Payload.ToString().ToLower().Contains(lowerQuery))
                .OrderByDescending(x => x.CreatedAt);
        }
    }
}
