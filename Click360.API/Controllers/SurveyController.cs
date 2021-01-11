using System;
using System.Collections.Generic;
using Click360.Core.DTOs;
using Click360.Core.Models;
using Click360.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Click360.API.Controllers
{
    /// <summary>
    /// Handles all Organization related activities for Click360
    /// </summary>
    public class SurveyController : BaseAPIController
    {
        private static readonly ILogger Logger = Log.ForContext<SurveyController>();
        private readonly ISurveyService SurveyService;

        /// <summary>
        /// OrganizationController Constructor
        /// </summary>
        /// <param name="surveyService"></param>
        public SurveyController(ISurveyService surveyService)
        {
            SurveyService = surveyService;
        }

        /// <summary>
        /// Save a survey
        /// </summary>
        /// <param name="surveyResponse"></param>
        /// <returns>Boolean</returns>
        [HttpPost]
        [Route("SaveSurvey")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> SaveSurvey([FromBody] SurveyAnswersDTO surveyResponse)
        {
            try
            {
                var response = SurveyService.SaveSurvey(surveyResponse);
                return Ok(response);
            }
            catch (Exception e)
            {
                Logger.Error(e, $"Error on saving a survey: {e.Message}");
                return HandleException(e, $"An error occurred while saving a survey. Please try again later or contact support.");
            }
        }

        /// <summary>
        /// Save multiple surveys
        /// </summary>
        /// <param name="surveyResponses"></param>
        /// <returns>Boolean</returns>
        [HttpPost]
        [Route("SaveMultipleSurveys")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> SaveMultipleSurveys([FromBody] List<SurveyAnswersDTO> surveyResponses)
        {
            try
            {
                var response = SurveyService.SaveMultipleSurveys(surveyResponses);
                return Ok(true);
            }
            catch (Exception e)
            {
                Logger.Error(e, $"Error on saving a survey: {e.Message}");
                return HandleException(e, $"An error occurred while saving a survey. Please try again later or contact support.");
            }
        }

        /// <summary>
        /// Method for getting surveys for a user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>List of Surveys</returns>
        [HttpGet]
        [Route("GetSurveys/{userID:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<SurveyMaster>> GetSurveys(Guid userID)
        {
            try
            {
                var surveys = SurveyService.GetSurveys(userID);
                return Ok(surveys);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error retrieving surveys for userID {userID}: {ex.Message}");
                return HandleException(ex, "An error occurred  retrieving surveys. Please try again later or contact support.");
            }
        }

        /// <summary>
        /// Method for getting survey questions
        /// </summary>
        /// <param name="questionTypeID"></param>
        /// <param name="likertScaleID"></param>
        /// <returns>List of Survey Questions with Likert lookups</returns>
        [HttpGet]
        [Route("GetSurveys/{questionTypeID:int}/{likertScaleID:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<SurveyQuestionsDTO>> GetSurveyQuestions(int questionTypeID, int likertScaleID)
        {
            try
            {
                var surveyQuestions = SurveyService.GetSurveyQuestions(questionTypeID, likertScaleID);
                return Ok(surveyQuestions);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error retrieving survey questions for questionTypeID {questionTypeID} and likertScaleID {likertScaleID}: {ex.Message}");
                return HandleException(ex, "An error occurred  retrieving survey questions. Please try again later or contact support.");
            }
        }
    }
}
