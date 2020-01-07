using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranslationsApi.Core.Abstractions.Services;
using TranslationsApi.Core.DTO;

namespace TranslationsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslationsController : ControllerBase
    {
        private ITranslationService translationService;

        public TranslationsController(ITranslationService service)
        {            
            translationService = service;
        }

        [HttpGet]
        public IEnumerable<OutLanguageDTO> GetAll()
        {
            return translationService.GetAll();
        }

        [HttpGet("{langCode}")]
        public ActionResult<OutLanguageDTO> GetByLangCode(string langCode)
        {
            try
            {
                var result = translationService.GetByLangCode(langCode);
                return result;
            }            
            catch(InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public ActionResult<OutLanguageDTO> Insert([FromBody]InLanguageDTO translation)
        {
            try
            {
                var result = translationService.Insert(translation);
                return result;
            }            
            catch(DbUpdateException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public ActionResult<OutLanguageDTO> Update([FromBody]InLanguageDTO translation)
        {
            try
            {
                var result = translationService.Update(translation);
                return result;
            }
            catch(DbUpdateException ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                translationService.Delete(id);
                return Ok();
            }            
            catch(ArgumentNullException ex)
            {
                return NotFound(ex);
            }
        }
    }
}
