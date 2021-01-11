using System;
using System.Collections.Generic;
using Click360.Core.Database.Interfaces;
using Click360.Core.DTOs;
using Click360.Core.Models;
using Click360.Core.Repositories.Interfaces;

namespace Click360.Core.Repositories
{
    /// <summary>
    /// Organization Repository
    /// </summary>
    public class SurveyRepository : ISurveyRepository
    {
        private readonly IClick360Database Click360Database;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataBase"></param>
        public SurveyRepository(IClick360Database dataBase)
        {
            Click360Database = dataBase;
        }

        ///<inheritdoc/>
        public void SaveResponses(QnResponses responses)
        {
            Click360Database.Insert<QnResponses>(responses);
        }

        /// <inheritdoc />
        public List<SurveyMaster> GetSurveys(Guid userID)
        {
            var sql = @"SELECT * FROM SurveyMaster WHERE ForUserID = @UserID";
            return Click360Database.Fetch<SurveyMaster>(sql, new { UserID = userID });
        }

        /// <inheritdoc />
        public List<LikertScaleLookup> GetLikertLookups(int likertScaleID)
        {
            var sql = @"SELECT * FROM LikertScaleLookup WHERE LikertScaleID = @LikertScaleID";
            return Click360Database.Fetch<LikertScaleLookup>(sql, new { LikertScaleID = likertScaleID });
        }

        /// <inheritdoc />
        public List<QnBehaviour> GetBehaviours(int questionTypeID)
        {
            var sql = @"SELECT * FROM QnBehaviour WHERE Id IN (7, @ID)";
            return Click360Database.Fetch<QnBehaviour>(sql, new { ID = questionTypeID });
        }

        /// <inheritdoc />
        public List<QnMaster> GetQuestions(int behaviourID)
        {
            var sql = @"SELECT * FROM QnMaster WHERE QnBhId = @BehaviourID";
            return Click360Database.Fetch<QnMaster>(sql, new { BehaviourID = behaviourID });
        }
    }
}
