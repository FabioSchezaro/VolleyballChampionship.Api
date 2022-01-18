namespace VolleyballChampionship.Dal.MySql.Commands
{
    public class PlayerCommands
    {
        public const string _getByParameters = @"";

        public const string _whereName = @"
                                    AND Description LIKE CONCAT ('%', @Name, '%')";


        public const string _whereNickName = @"
                                     AND Nickname LIKE CONCAT ('%', @Nickname, '%')";

        public const string _wherePlayerId = @"
                                    AND Id = @Id ";
    }
}

