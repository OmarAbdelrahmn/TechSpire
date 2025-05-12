using Microsoft.AspNetCore.Identity;


namespace TechSpire.Domain.Entities;
public class ApplicataionUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public List<RefreshToken> RefreshTokens { get; set; } = [];
    public bool IsDisabled { get; set; } = false;
    public List<int> CompletedLessonIds { get; set; } = [];

    // Key: StageId, Value: percentage (0–100)
    public Dictionary<int, double> GetStageProgress(List<Stage> stages)
    {
        var progress = new Dictionary<int, double>();
        foreach (var stage in stages)
        {
            var total = stage.Lessons.Count;
            var completed = stage.Lessons.Count(l => CompletedLessonIds.Contains(l.Id));
            double percentage = total == 0 ? 0 : completed / (double)total * 100;
            progress[stage.Id] = percentage;
        }
        return progress;
    }
}
