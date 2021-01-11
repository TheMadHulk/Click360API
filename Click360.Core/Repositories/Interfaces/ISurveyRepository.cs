using System;
using System.Collections.Generic;
using Click360.Core.DTOs;
using Click360.Core.Models;

namespace Click360.Core.Repositories.Interfaces
{
    /// <summary>
    /// Handles the organization related data.
    /// </summary>
    public interface ISurveyRepository
    {
        /// <summary>
        /// Method for getting surveys for a user
        /// </summary>
        /// <returns>List of Surveys</returns>
        List<SurveyMaster> GetSurveys(Guid userID);

        /// <summary>
        /// Method to insert response
        /// </summary>
        /// <param name="responses"></param>
        void SaveResponses(QnResponses responses);

        /// <summary>
        /// GetLikert Lookups
        /// </summary>
        /// <param name="likertScaleID"></param>
        /// <returns>List of LikertScaleLookup</returns>
        List<LikertScaleLookup> GetLikertLookups(int likertScaleID);

        /// <summary>
        /// Get Behaviours
        /// </summary>
        /// <param name="questionTypeID"></param>
        /// <returns>List of QnBehaviour</returns>
        List<QnBehaviour> GetBehaviours(int questionTypeID);

        /// <summary>
        /// Get Questions
        /// </summary>
        /// <param name="behaviourID"></param>
        /// <returns>List of QnMaster</returns>
        List<QnMaster> GetQuestions(int behaviourID);
    }
}
