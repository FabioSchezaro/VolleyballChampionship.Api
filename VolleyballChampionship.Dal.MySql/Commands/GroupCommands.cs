namespace VolleyballChampionship.Dal.MySql.Commands
{
    public class GroupCommands
    {
        public const string _getByParameters = @"";

        public const string _whereDescription = @"
                                    AND Description LIKE CONCAT ('%', @Description, '%')";


        public const string _whereChampionshipId = @"
                                    AND ChampionshipId = @ChampionshipId ";

        public const string _whereGroupId = @"
                                    AND Id = @Id ";
    }
}

