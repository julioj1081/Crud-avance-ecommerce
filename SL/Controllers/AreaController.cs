﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class AreaController : ApiController
    {
        // GET: api/Area
        [HttpGet]
        [Route("api/Area")]
        public IHttpActionResult GetAllArea()
        {
            ML.Result result = BL.Area.GetAllArea();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Area/5
        [HttpGet]
        [Route("api/Area/{IdArea}")]
        public IHttpActionResult GetByIdArea(int IdArea)
        {
            ML.Result result = BL.Area.GetByIdArea(IdArea);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Area
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Area/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Area/5
        public void Delete(int id)
        {
        }
    }
}
