namespace Click360.Core.Enums
{
    public enum SurveyStatus
    {
        /// <summary>
        /// Not Started (0)
        /// </summary>
        NotStarted = 0,

        /// <summary>
        /// In Progress (1)
        /// </summary>
        InProgress = 1,

        /// <summary>
        /// Completed (2)
        /// </summary>
        Completed = 2,
    }

    public static class SurveyStatusConstants
    {
        /// <summary>
        /// Not Started (0)
        /// </summary>
        public const string NotStarted = "Not Started";

        /// <summary>
        /// In Progress (1)
        /// </summary>
        public const string InProgress = "In Progress";

        /// <summary>
        /// Completed (2)
        /// </summary>
        public const string Completed = "Completed";

        /// <summary>
        /// Get the display string for an enum by it's value in integer form
        /// </summary>
        /// <param name="value">The enum value in integer form</param>
        /// <returns>The display string for the value or the default if one cannot be found</returns>
        public static string GetByEnum(int value)
        {
            switch (value)
            {
                case (int)SurveyStatus.NotStarted:
                    return NotStarted;

                case (int)SurveyStatus.InProgress:
                    return InProgress;

                case (int)SurveyStatus.Completed:
                    return Completed;

                default:
                    return NotStarted;
            }
        }

        /// <summary>
        /// Get the display string for an enum by it's value in enum form
        /// </summary>
        /// <param name="value">The enum value in enum form</param>
        /// <returns>The display string for the value or the default if one cannot be found</returns>
        public static string GetByEnum(SurveyStatus value)
        {
            return GetByEnum((int)value);
        }
    }
}
