using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HotelWebApi.Models;
using HotelWebApi.Repositories;

namespace HotelWebApi.Controllers
{
    public class BranchController : ApiController
    {
        private readonly IRepository<Branch> BranchRepoistory;
     
        public BranchController(IRepository<Branch> _repository)
        {
            BranchRepoistory = _repository;
        }

        // GET: api/Branch
        public IHttpActionResult GetBranchs()
        {
            var list = BranchRepoistory.GetAllItems();
            return Ok(list);
        }

        // GET: api/Branch/5
        [ResponseType(typeof(Branch))]
        public IHttpActionResult GetBranch(int id)
        {
            Branch branch = BranchRepoistory.GetItem(id.ToString());
            if (branch == null)
            {
                return NotFound();
            }

            return Ok(branch);
        }

        // PUT: api/Branch/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBranch(int id, Branch branch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != branch.BranchId)
            {
                return BadRequest();
            }

            try
            {
                BranchRepoistory.EditItem(branch);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (BranchExists(id)==null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Branch
        [ResponseType(typeof(Branch))]
        public IHttpActionResult PostBranch(Branch branch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BranchRepoistory.AddItem(branch);

            return CreatedAtRoute("DefaultApi", new { id = branch.BranchId }, branch);
        }

        // DELETE: api/Branch/5
        [ResponseType(typeof(Branch))]
        public IHttpActionResult DeleteBranch(int id)
        {
            Branch branch = BranchRepoistory.GetItem(id.ToString());
            if (branch == null)
            {
                return NotFound();
            }

            BranchRepoistory.DeleteItem(id.ToString());

            return Ok(branch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                BranchRepoistory.Dispose();
            }
            base.Dispose(disposing);
        }

        private Branch BranchExists(int id)
        {
            return BranchRepoistory.GetItem(id.ToString());
        }
    }
}