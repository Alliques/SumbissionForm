using SubmittingForm.Domain;

namespace SubmittingForm.Application
{
    /// <summary>
    /// Defines methods for working with <see cref="Submission"/> entities in the data store
    /// </summary>
    public interface ISubmissionRepository
    {
        /// <summary>
        /// Adds a new <see cref="Submission"/> to the data store
        /// </summary>
        /// <param name="submission">The submission entity to add</param>
        /// <returns></returns>
        Task AddAsync(Submission submission);

        /// <summary>
        /// Retrieves all submissions from the data store
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Submission>> GetAllAsync();
    }
}
