﻿using LahjatunaAPI.Dtos.Language;
using LahjatunaAPI.Interfaces;
using LahjatunaAPI.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LahjatunaAPI.Controllers.Languages
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [Authorize]
        [HttpGet("getAllLanguages")]
        public async Task<ActionResult> GetAllLanguagesAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var languages = await _languageService.GetAllLanguagesAsync();

                var languagesDtos = languages.Select(x => x.ToLanguageDto()).ToList();

                var totalLanguages = languagesDtos.Count;

                return Ok(new { totalLanguages,  languages = languagesDtos });

            } catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("getLanguage/{id}")]
        public async Task<ActionResult> GetLanguageByIdAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var language = await _languageService.GetLanguageByIdAsync(id);

                var languageDto = language.ToLanguageDto();

                return Ok(new { languageDto });

            } catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost("addLanguage")]
        public async Task<ActionResult> AddLanguageAsync([FromBody] CreateLanguageDto language)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newLanguage = await _languageService.AddLanguageAsync(language);

                var newLanguageDto = newLanguage.ToLanguageDto();

                return Ok(new { newLanguageDto });

            } catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut("updateLanguage")]
        public async Task<ActionResult> UpdateLanguageAsync([FromBody] UpdateLanguageDto language)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedLanguage = await _languageService.UpdateLanguageAsync(language);

                var updatedLanguageDto = updatedLanguage.ToLanguageDto();

                return Ok(new { updatedLanguageDto });

            } catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("deleteLanguage/{id}")]
        public async Task<ActionResult> DeleteLanguageAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _languageService.DeleteLanguageAsync(id);

                return Ok(new { message = "language deleted successfully."});

            } catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        
    }
}