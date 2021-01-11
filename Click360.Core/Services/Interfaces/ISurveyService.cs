using System;
using System.Collections.Generic;
using Click360.Core.DTOs;
using Click360.Core.Models;

namespace Click360.Core.Services.Interfaces
{
    public interface ISurveyService
    {
        /// <summary>
        /// Save a survey
        /// </summary>
        /// <param name="surveyResponse"></param>
        /// <returns>true/false</returns>
        bool SaveSurvey(SurveyAnswersDTO surveyResponse);

        /// <summary>
        /// Save multiple surveys
        /// </summary>
        /// <param name="surveyResponse"></param>
        /// <returns>true/false</returns>
        bool SaveMultipleSurveys(List<SurveyAnswersDTO> surveyResponses);

        /// <summary>
        /// Method for getting surveys for a user
        /// </summary>
        /// <returns>List of Surveys</returns>
        List<SurveyMaster> GetSurveys(Guid userID);

        /// <summary>
        /// Method for getting survey questions
        /// </summary>
        /// <param name="questionTypeID"></param>
        /// <param name="likertScaleID"></param>
        /// <returns>Survey Questions with Likert lookups</returns>
        SurveyQuestionsDTO GetSurveyQuestions(int questionTypeID, int likertScaleID);
    }
}
