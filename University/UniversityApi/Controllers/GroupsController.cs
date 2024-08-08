using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UniversityApi.Data.DTOs.Groups;
using UniversityApi.Data.Entities;
using UniversityApi.Service.Interfaces;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GroupPostDTO> _validator;

        public GroupsController(IGroupRepository groupRepository, IMapper mapper, IValidator<GroupPostDTO> validator)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
            _validator = validator;
        }

        // GET: api/<GroupsController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Group> groups = _groupRepository.GetAll();
            List<GroupGetDTO> data = _mapper.Map<List<GroupGetDTO>>(groups);
            return Ok(data);
        }

        // GET api/<GroupsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Group group = _groupRepository.GetById(id);
            if (group is null) return NotFound();
            GroupGetDTO data = _mapper.Map<GroupGetDTO>(group);
            return Ok(data);
        }

        // POST api/<GroupsController>
        [HttpPost]
        public IActionResult Post([FromForm] GroupPostDTO entity)
        {
            ValidationResult result = _validator.Validate(entity);
            if (!result.IsValid)
            {
                return BadRequest(new
                {
                    Status = "error",
                    Messages = result.Errors.Select(x => x.ErrorMessage).ToList(),
                });
            }

            try
            {
                Group group = _mapper.Map<Group>(entity);
                _groupRepository.Add(group);
                return CreatedAtAction(nameof(Get), new { id = group.Id }, new
                {
                    Status = "success",
                    Message = "Successfully created",
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = "Error",
                    Message = ex.Message,
                });
            }
        }

        // PUT api/<GroupsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] GroupPostDTO entity)
        {
            ValidationResult result = _validator.Validate(entity);
            if (!result.IsValid)
            {
                return BadRequest(new
                {
                    Status = "error",
                    Messages = result.Errors.Select(x => x.ErrorMessage).ToList(),
                });
            }

            try
            {
                Group group = _mapper.Map<Group>(entity);
                _groupRepository.Update(id, group);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = "Error",
                    Message = ex.Message,
                });
            }
        }

        // DELETE api/<GroupsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Group group = _groupRepository.GetById(id);
                if (group is null) return NotFound();
                _groupRepository.Delete(group);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = "Error",
                    Message = ex.Message,
                });
            }
        }
    }
}
