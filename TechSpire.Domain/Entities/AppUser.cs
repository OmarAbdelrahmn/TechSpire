using Microsoft.AspNet.Identity.EntityFramework;


namespace TechSpire.Domain.Entity;
public class AppUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public List<int> CompletedLessonIds { get; set; } = [];

    // Key: StageId, Value: percentage (0–100)
    public Dictionary<int, double> GetStageProgress(List<Stage> stages)
    {
        var progress = new Dictionary<int, double>();
        foreach (var stage in stages)
        {
            var total = stage.Lessons.Count;
            var completed = stage.Lessons.Count(l => CompletedLessonIds.Contains(l.Id));
            double percentage = total == 0 ? 0 : (completed / (double)total) * 100;
            progress[stage.Id] = percentage;
        }
        return progress;
    }
}
