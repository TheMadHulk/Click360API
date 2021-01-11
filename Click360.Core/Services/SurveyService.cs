using System;
using System.Collections.Generic;
using Click360.Core.DTOs;
using Click360.Core.Enums;
using Click360.Core.Models;
using Click360.Core.Repositories.Interfaces;
using Click360.Core.Services.Interfaces;
using Serilog;

namespace Click360.Core.Services
{
    /// <summary>
    /// Organization service
    /// </summary>
    public class SurveyService : ISurveyService
    {
        private static readonly ILogger Logger = Log.ForContext<SurveyService>();
        private ISurveyRepository SurveyRepository;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="surveyRepository"></param>
        public SurveyService(ISurveyRepository surveyRepository)
        {
            SurveyRepository = surveyRepository;
        }

        /// <inheritdoc/>
        public bool SaveSurvey(SurveyAnswersDTO surveyResponse)
        {
            foreach(var answer in surveyResponse.Answers)
            {
                var answerEntry = new QnResponses
                {
                    QmID = answer.QmID,
                    Response = answer.Response,
                    SurveyID = surveyResponse.SurveyID
                };
                SurveyRepository.SaveResponses(answerEntry);
            }
            return true;
        }

        /// <inheritdoc/>
        public bool SaveMultipleSurveys(List<SurveyAnswersDTO> surveyResponses)
        {
            foreach (var surveyResponse in surveyResponses)
            {
                SaveSurvey(surveyResponse);
            }
            return true;
        }


        /// <inheritdoc/>
        public List<SurveyMaster> GetSurveys(Guid userID)
        {
            var surveys = SurveyRepository.GetSurveys(userID);
            foreach(var survey in surveys)
            {
                survey.Status = SurveyStatusConstants.GetByEnum(int.Parse(survey.Status));
            }
            return surveys;
        }

        /// <inheritdoc/>
        public SurveyQuestionsDTO GetSurveyQuestions(int questionTypeID, int likertScaleID)
        {
            var likertLookups = SurveyRepository.GetLikertLookups(likertScaleID);
            var behaviours = SurveyRepository.GetBehaviours(questionTypeID);
            var behaviourList = new List<BehaviourDTO>();
            foreach (var behaviour in behaviours)
            {
                var questions = SurveyRepository.GetQuestions(behaviour.Id);
                behaviourList.Add(new BehaviourDTO(behaviour, questions));
            }

            var surveyQuestion = new SurveyQuestionsDTO()
            {
                LikertScale = likertLookups,
                Behaviours = behaviourList
            };
            
            return surveyQuestion;
        }
    }
}
