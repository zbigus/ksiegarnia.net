﻿using BookStore.Entities.Models;
using BookStore.Logic.Interfaces;
using BookStore.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.SPA.Controllers
{
    public class CategoriesController : BaseApiController
    {
        public CategoriesController(IRepository repo) : base(repo) { }

        public IHttpActionResult Get()
        {
            return Ok(Repo.GetAllCategories().ToList());
        }

        public IHttpActionResult Post([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Repo.AddCategory(category.Name))
            {
                return CreatedAtRoute("DefaultApi", new { id = category.Id }, TheModelFactory.Create(category));
            }
            return Conflict();
        }
    }
}