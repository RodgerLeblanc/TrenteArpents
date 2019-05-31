using System.Collections.Generic;
using System.Threading.Tasks;
using TrenteArpents.Models;

namespace TrenteArpents.Helpers
{
    public interface IHeartService
    {
        Task<IEnumerable<HeartInfo>> GetAsync();
        Task<HeartInfo> GetAsync(int activityId);
    }
}