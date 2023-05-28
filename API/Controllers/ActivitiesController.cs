using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{

  public class ActivitiesController : BaseApiController
  {
    private readonly DataContext _contex;

    public ActivitiesController(DataContext contex)
    {
      _contex = contex;
    }

    [HttpGet("getAllActivities")]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
      return await _contex.Activities.ToListAsync();
    }

    [HttpGet("getActivityById")]
    public async Task<ActionResult<Activity>> GetActivity(Guid id)
    {
      return await _contex.Activities.FirstAsync(x=>x.Id == id);
    }

    [HttpPost]
    public ActionResult<Activity> AddActivity([FromBody]Activity activity)
    {
       _contex.Activities.Add(activity);
     _contex.SaveChanges();
      return activity;
      
    }
  }
}
