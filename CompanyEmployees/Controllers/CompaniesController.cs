﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CompaniesController(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _logger = loggerManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
                var companies = _repository.Company.GetAllCompanies(false);
                var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

                return Ok(companiesDto);
        }

        [HttpGet("{id}", Name = "CompanyById")]
        public IActionResult GetCompany(Guid id)
        {
            var company = _repository.Company.GetCompany(id, trackChanges: false);
            if (company == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var companyDto = _mapper.Map<CompanyDto>(company);
                return Ok(companyDto);
            }
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody]CompanyForCreationDto company)
        {
            if(company == null)
            {
                _logger.LogError("object sent from client is null");
                return BadRequest("object is null");
            }

            var companyEntity = _mapper.Map<Company>(company); 
            _repository.Company.CreateCompany(companyEntity); 
            _repository.Save(); var companyToReturn = _mapper.Map<CompanyDto>(companyEntity); 
            return CreatedAtRoute("CompanyById", new { id = companyToReturn.Id }, companyToReturn);
        }
    }
}
