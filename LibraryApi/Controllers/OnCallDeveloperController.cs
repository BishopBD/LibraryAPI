using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    public class OnCallDeveloperController : ControllerBase
    {
        ILookupOnCallDevelopers OnCallLookup;

        public OnCallDeveloperController(ILookupOnCallDevelopers onCallLookup)
        {
            OnCallLookup = onCallLookup;
        }

        [HttpGet("/oncalldeveloper")]
        public async Task<ActionResult> GetOnCallDeveloper()
        {
            OnCallDeveloperResponse response = await OnCallLookup.GetDeveloper();
            return Ok(response);
        }
    }
}
