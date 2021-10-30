using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.HubConfig;
using PaymentAPI.Models;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IHubContext<ChartHub> _hub;
        public VideoGamesController(ApplicationDbContext context, IHubContext<ChartHub> hub)
        {
            _context = context;
            _hub = hub;
        }

        // GET: api/VideoGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChartModel>>> Get()
        {
            var vg=  await _context.VideoGames.ToListAsync();
            var status1 = vg.Count(x => x.Platform == "PS");
            var status2 = vg.Count(x => x.Platform == "PC");
            var status3 = vg.Count(x => x.Platform == "XBOX");
            List<ChartModel> chartModels = new List<ChartModel>();
            chartModels.Add(new ChartModel { Data = new List<int> { status1 }, Label = "PS" });
            chartModels.Add(new ChartModel { Data = new List<int> { status2 }, Label = "PC" });
            chartModels.Add(new ChartModel { Data = new List<int> { status3 }, Label = "XBOX" });
            //await _hub.Clients.All.SendAsync("transferchartdata", chartModels);
            return chartModels;
        }

        // GET: api/VideoGames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGame(int id)
        {
            var videoGame = await _context.VideoGames.FindAsync(id);

            if (videoGame == null)
            {
                return NotFound();
            }

            return videoGame;
        }

        // PUT: api/VideoGames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoGame(int id, VideoGame videoGame)
        {
            if (id != videoGame.VideogameId)
            {
                return BadRequest();
            }

            _context.Entry(videoGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoGameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VideoGames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VideoGame>> PostVideoGame(VideoGame videoGame)
        {
            _context.VideoGames.Add(videoGame);
            await _context.SaveChangesAsync();
            await _hub.Clients.All.SendAsync("transferchartdata", new List<ChartModel>());
            return CreatedAtAction("Get", new { id = videoGame.VideogameId }, videoGame);
        }

        // DELETE: api/VideoGames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoGame(int id)
        {
            var videoGame = await _context.VideoGames.FindAsync(id);
            if (videoGame == null)
            {
                return NotFound();
            }

            _context.VideoGames.Remove(videoGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideoGameExists(int id)
        {
            return _context.VideoGames.Any(e => e.VideogameId == id);
        }
    }
}
