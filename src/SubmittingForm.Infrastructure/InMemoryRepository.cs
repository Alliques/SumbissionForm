using SubmittingForm.Application;
using SubmittingForm.Domain;

namespace SubmittingForm.Infrastructure
{
    public class InMemoryRepository : ISubmissionRepository
    {
        private static readonly List<Submission> _db = new();

        public Task AddAsync(Submission submission)
        {
            _db.Add(submission);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Submission>> GetAllAsync()
        {
            return Task.FromResult(_db.AsEnumerable());
        }
    }
}
