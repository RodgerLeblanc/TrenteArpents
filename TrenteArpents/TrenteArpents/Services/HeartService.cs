using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrenteArpents.Models;

namespace TrenteArpents.Helpers
{
    public class HeartService : IHeartService
    {
        public async Task<IEnumerable<HeartInfo>> GetAsync()
        {
            await Task.CompletedTask;
            return Enumerable.Empty<HeartInfo>();
        }

        public async Task<HeartInfo> GetAsync(int activityId)
        {
            await Task.CompletedTask;
            return new HeartInfo();
        }
    }
}
